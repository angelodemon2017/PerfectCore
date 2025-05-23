using UnityEngine;

public class PlayerPrefsPersistenceService : IDataPersistenceService
{
    private const string KEY_PREFIX = "DATA_";

    public bool SaveModel<T>(T model, string filePath) where T : class, IDataModel
    {
        try
        {
            string key = GetKey<T>(filePath);
            string jsonData = JsonUtility.ToJson(model);
            PlayerPrefs.SetString(key, jsonData);
            PlayerPrefs.Save();
            Debug.Log($"Model {typeof(T)} saved to PlayerPrefs with key {key}");
            return true;
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to save model {typeof(T)} to PlayerPrefs: {e.Message}");
            return false;
        }
    }

    public T LoadModel<T>(string filePath) where T : class, IDataModel
    {
        string key = GetKey<T>(filePath);

        if (!PlayerPrefs.HasKey(key))
        {
            Debug.LogWarning($"Key {key} not found in PlayerPrefs");
            return null;
        }

        try
        {
            string jsonData = PlayerPrefs.GetString(key);
            var model = JsonUtility.FromJson<T>(jsonData);
            Debug.Log($"Model {typeof(T)} loaded from PlayerPrefs with key {key}");
            return model;
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to load model {typeof(T)} from PlayerPrefs: {e.Message}");
            return null;
        }
    }

    public string GetModelPath<T>() where T : class, IDataModel
    {
        return $"{typeof(T).Name}";
    }

    private string GetKey<T>(string filePath) where T : class, IDataModel
    {
        return $"{KEY_PREFIX}{filePath ?? GetModelPath<T>()}";
    }
}