using UnityEngine;
using Zenject;

public class LoadingWindow : UIWindow
{
    [SerializeField] private GameObject _gameObject;

    [Inject] private SceneService sceneService;
    
    public override void Show()
    {
        _gameObject.SetActive(false);
        sceneService.OnLevelLoaded += LevelLoaded;
    }

    private void LevelLoaded(int level)
    {
        _gameObject.SetActive(true);
    }

    public override void Hide()
    {

    }
}