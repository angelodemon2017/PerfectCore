using System;
using UnityEngine;

[Serializable]
public class SettingsModel : IDataModel
{
    public string ModelName => "Game Settings";

    [Range(0f, 1f)]
    public float MusicVolume = 0.7f;
    [Range(0f, 1f)]
    public float SfxVolume = 0.8f;
    public bool VibrationEnabled = true;
    public SystemLanguage language = SystemLanguage.Russian;

    public void UpdateModelByLiteMessage(string message)
    {

    }

    public string GetLiteMessage(int deepH = 0)
    {
        return string.Empty;
    }
}