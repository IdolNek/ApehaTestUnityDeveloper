using Infrastructure.Services.ServiceLocater;
using Infrastructure.StateMachine;

namespace Infrastructure
{
    public class Game
    {
        private GameStateMachine _gameStateMachine;
        public GameStateMachine GameStateMachine => _gameStateMachine;

        public Game(ICoroutineRunner coroutineRunner) => 
            _gameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), new AllServices());

    }
}