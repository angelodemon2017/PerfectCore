using UnityEngine;

public class PauseMenuState : GameStateBase
{
    private readonly SceneService _sceneService;
    private readonly FSMService _fsmService;
    private readonly UIService _uiManager;

    private PauseWindow _pauseWindow;
    private int Counter;

    public PauseMenuState(
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
        _pauseWindow = _uiManager.ChangeWindow<PauseWindow>();
        UpdateUI();
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _fsmService.ChangeState<GameplayState>();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _sceneService.LoadLevel(0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Counter++;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        _pauseWindow.UpdateView(Counter);
    }

    public override void ExitState() { }
}