using UnityEngine;

public class MainMenuState : GameStateBase
{
    private readonly FSMService _fsmService;
    private readonly UIService _uiManager;

    public MainMenuState(FSMService fsmService, UIService uiManager)
    {
        _fsmService = fsmService;
        _uiManager = uiManager;
    }

    public override void EnterState()
    {
        _uiManager.ChangeWindow<MainMenuWindow>();
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _fsmService.ChangeState<GameplayState>();
        }
    }

    public override void ExitState() { }
}