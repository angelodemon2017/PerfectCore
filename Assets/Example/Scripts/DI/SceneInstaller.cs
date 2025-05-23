using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
    }

    public override void Start()
    {
        var fsmService = Container.Resolve<FSMService>();
        fsmService.ChangeState<MainMenuState>();
    }
}