public abstract class GameStateBase : IState
{
    public virtual string StateName => GetType().Name;
    public virtual bool CanExit => true;

    public abstract void EnterState();
    public abstract void Update();
    public abstract void ExitState();
}