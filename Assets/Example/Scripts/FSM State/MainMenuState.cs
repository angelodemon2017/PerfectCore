public class MainMenuState : GameStateBase
{
    private readonly SceneService _sceneService;
    private readonly FSMService _fsmService;
    private readonly UIService _uiManager;

    private MainMenuWindow _mainMenuWindow;

    public MainMenuState(
        FSMService fsmService,
        UIService uiManager,
        SceneService sceneService)
    {
        _fsmService = fsmService;
        _uiManager = uiManager;
        _sceneService = sceneService;
    }

    public override void EnterState()
    {
        _mainMenuWindow = _uiManager.ChangeWindow<MainMenuWindow>();
        _mainMenuWindow._playBtn.onClick.AddListener(OnPlay);
    }

    private void OnPlay()
    {
        _sceneService.LoadLevel(1);
    }

    public override void Update()
    {
    }

    public override void ExitState() 
    {
        _mainMenuWindow._playBtn.onClick.RemoveListener(OnPlay);
    }
}