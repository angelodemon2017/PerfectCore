public interface IFSM<TState> where TState : IState
{
    TState GetCurrentState { get; }

    void ChangeState<T>() where T : TState;
}