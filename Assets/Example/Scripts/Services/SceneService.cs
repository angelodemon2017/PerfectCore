using Services;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneService : ISceneService, IInitializable
{
    public event Action<int> OnLevelLoaded;

    private UIService _uiService;
    private readonly LevelsConfig _levelsConfig;
    private ILevelConfig _currentLevel;

    public SceneService(LevelsConfig levelsConfig, UIService uiService)
    {
        _levelsConfig = levelsConfig;
        _uiService = uiService;
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

//        _uiService.ChangeWindow<LoadingWindow>();
        _currentLevel = levelConfig;
        SceneManager.LoadScene(levelConfig.Scene);
        OnLevelLoaded?.Invoke(levelConfig.LevelNumber);
    }

    public ILevelConfig GetCurrentLevelConfig()
    {
        return _currentLevel;
    }
}