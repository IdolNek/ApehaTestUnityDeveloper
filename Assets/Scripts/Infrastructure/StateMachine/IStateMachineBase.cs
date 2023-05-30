using Infrastructure.Services;

namespace Infrastructure.StateMachine
{
    public interface IStateMachineBase : IService
    {
        void Enter<TState>() where TState : class, IState;
    }
}