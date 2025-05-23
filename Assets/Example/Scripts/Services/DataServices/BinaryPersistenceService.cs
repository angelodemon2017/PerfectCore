using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class BinaryPersistenceService : IDataPersistenceService
{
    private const string DATA_FOLDER_NAME = "BinaryData";
    private readonly string _dataFolderPath;

    public BinaryPersistenceService()
    {
        _dataFolderPath = Path.Combine(Application.persistentDataPath, DATA_FOLDER_NAME);

        if (!Directory.Exists(_dataFolderPath))
        {
            Directory.CreateDirectory(_dataFolderPath);
        }
    }

    public bool SaveModel<T>(T model, string filePath) where T : class, IDataModel
    {
        string fullPath = GetFullPath(filePath ?? GetModelPath<T>());

        try
        {
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, model);
            }

            Debug.Log($"Model {typeof(T)} saved in binary format to {fullPath}");
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to save model {typeof(T)} in binary format: {e.Message}");
            return false;
        }
    }

    public T LoadModel<T>(string filePath) where T : class, IDataModel
    {
        string fullPath = GetFullPath(filePath ?? GetModelPath<T>());

        if (!File.Exists(fullPath))
        {
            Debug.LogWarning($"Binary file not found at {fullPath}");
            return null;
        }

        try
        {
            using (FileStream stream = new FileStream(fullPath, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                T model = (T)formatter.Deserialize(stream);
                Debug.Log($"Model {typeof(T)} loaded from binary file {fullPath}");
                return model;
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to load model {typeof(T)} from binary file: {e.Message}");
            return null;
        }
    }

    public string GetModelPath<T>() where T : class, IDataModel
    {
        return $"{typeof(T).Name}.dat";
    }

    private string GetFullPath(string relativePath)
    {
        return Path.Combine(_dataFolderPath, relativePath);
    }
}