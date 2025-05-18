using UnityEngine;

public class GameplayState : GameStateBase
{
    private readonly FSMService _fsmService;
    private readonly UIService _uiService;
    private readonly SceneService _sceneService;

    public override string StateName => "Gameplay";

    public GameplayState(
        FSMService fsmService,
        SceneService sceneService,
        UIService uiService)
    {
        _fsmService = fsmService;
        _sceneService = sceneService;
        _uiService = uiService;
    }

    public override void EnterState()
    {
        _uiService.ChangeWindow<PauseWindow>();
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _fsmService.ChangeState<MainMenuState>();
        }
    }

    public override void ExitState() { }
}