using Services;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneService : ISceneService, IInitializable
{
    public event Action<string> OnLevelLoaded;

    private readonly LevelsConfig _levelsConfig;
    private ILevelConfig _currentLevel;

    public SceneService(LevelsConfig levelsConfig)
    {
        _levelsConfig = levelsConfig;
    }

    public void Initialize()
    {

    }

    public void LoadLevel(int levelNumber)
    {
        var levelConfig = _levelsConfig.GetLevelByNumber(levelNumber);
        if (levelConfig == null)
        {
            Debug.LogError($"Level with number {levelNumber} not found!");
            return;
        }

        _currentLevel = levelConfig;
        SceneManager.LoadScene(levelConfig.Scene);
        OnLevelLoaded?.Invoke(levelConfig.Scene);
    }

    

    public ILevelConfig GetCurrentLevelConfig()
    {
        return _currentLevel;
    }
}
