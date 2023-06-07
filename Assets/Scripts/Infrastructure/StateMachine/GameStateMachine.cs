using System;
using System.Collections.Generic;
using Infrastructure.Factory;
using Infrastructure.Services.ServiceLocater;
using Infrastructure.Services.StaticData;
using Infrastructure.StateMachine.State;
using Infrastructure.UI.Factory;

namespace Infrastructure.StateMachine
{
    public class GameStateMachine : StateMachineBase
    {
        public GameStateMachine(Infrastructure.SceneLoader sceneLoader, AllServices allServices)
        {
            _states = new Dictionary<Type, IExitAbleState>
            {
                [typeof(BootStrapState)] = new BootStrapState(this, sceneLoader, allServices),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, allServices.Single<IGameFactory>(), allServices.Single<IStaticDataService>()
                    , allServices.Single<IUIFactory>()),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayLoadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }
    }
}