using UnityEngine;

public class PauseMenuState : GameStateBase
{
    private readonly FSMService _fsmService;
    private readonly UIService _uiManager;

    private PauseWindow _pauseWindow;
    private int Counter;

    public PauseMenuState(FSMService fsmService, UIService uiManager)
    {
        _fsmService = fsmService;
        _uiManager = uiManager;
    }

    public override void EnterState()
    {
        _pauseWindow = _uiManager.ChangeWindow<PauseWindow>();
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _fsmService.ChangeState<GameplayState>();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Counter++;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        _pauseWindow.UpdateView();
    }

    public override void ExitState() { }
}