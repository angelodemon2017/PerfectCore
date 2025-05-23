using System;
using System.IO;
using UnityEngine;

public class JsonDataPersistenceService : IDataPersistenceService
{
    private const string DATA_FOLDER_NAME = "GameData";
    private readonly string _dataFolderPath;

    public JsonDataPersistenceService()
    {
        _dataFolderPath = Path.Combine(Application.persistentDataPath, DATA_FOLDER_NAME);

        if (!Directory.Exists(_dataFolderPath))
        {
            Directory.CreateDirectory(_dataFolderPath);
        }
    }

    public bool SaveModel<T>(T model, string filePath) where T : class, IDataModel
    {
        try
        {
            var fullPath = GetFullPath(filePath);
            string jsonData = JsonUtility.ToJson(model, prettyPrint: true);
            File.WriteAllText(fullPath, jsonData);
            Debug.Log($"Model {typeof(T)} saved to {fullPath}");
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to save model {typeof(T)}: {e.Message}");
            return false;
        }
    }

    public T LoadModel<T>(string filePath) where T : class, IDataModel
    {
        try
        {
            var fullPath = GetFullPath(filePath);

            if (!File.Exists(fullPath))
            {
                Debug.LogWarning($"File not found at {fullPath}");
                return null;
            }

            string jsonData = File.ReadAllText(fullPath);
            var model = JsonUtility.FromJson<T>(jsonData);
            Debug.Log($"Model {typeof(T)} loaded from {fullPath}");
            return model;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to load model {typeof(T)}: {e.Message}");
            return null;
        }
    }

    public string GetModelPath<T>() where T : class, IDataModel
    {
        // Генерируем стандартный путь на основе типа модели
        return $"{typeof(T).Name}.json";
    }

    private string GetFullPath(string relativePath)
    {
        return Path.Combine(_dataFolderPath, relativePath);
    }
}