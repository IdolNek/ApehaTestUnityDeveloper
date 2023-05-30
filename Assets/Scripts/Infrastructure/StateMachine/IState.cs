namespace Infrastructure.StateMachine
{
    public interface IState : IExitAbleState
    {
        void Enter();
    }
}