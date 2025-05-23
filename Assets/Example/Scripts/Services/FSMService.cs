using Zenject;

public class FSMService : IInitializable, ITickable, IFSM<GameStateBase>
{
    private DiContainer _container;
    private UIService _uiService;
    private GameStateBase _currentState;
    private SceneService _sceneService;

    public GameStateBase GetCurrentState => _currentState;

    public FSMService(DiContainer container, UIService uiService, SceneService sceneService)
    {
        _container = container;
        _uiService = uiService;
        _sceneService = sceneService;
        _sceneService.OnLevelLoaded += OnSceneLoaded;
    }

    public void ChangeState<TState>() where TState : GameStateBase
    {
        _currentState?.ExitState();
        var nextState = _container.Resolve<TState>();
        _currentState = nextState;
        _currentState.EnterState();
    }

    public void Initialize()
    {

    }

    private void OnSceneLoaded(int level)
    {
        switch (level)
        {
            case 0:
                ChangeState<MainMenuState>();
                break;
            case 1:
                ChangeState<GameplayState>();
                break;
        }
    }

    public void Tick()
    {
        _currentState?.Update();
//        TestUI();
//        CheckSpawnByPool();
    }

    /*    private void TestUI()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                var mmw = _container.Resolve<MainMenuWindow>();
                _uiService.OnGameStateChanged(mmw);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                var pw = _container.Resolve<PauseWindow>();
                _uiService.OnGameStateChanged(pw);
            }
        }/**/

    /*    private void CheckSpawnByPool()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                var tpo = _factoryTPO.Create();
                tpo.Counter = counter;
                counter++;
                _ltpo.Add(tpo);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                _ltpo[0].Close();
                _ltpo.RemoveAt(0);
            }
        }/**/
}