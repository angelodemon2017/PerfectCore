using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var fsmService = Container.Resolve<FSMService>();
        fsmService.ChangeState<MainMenuState>();
    }
}