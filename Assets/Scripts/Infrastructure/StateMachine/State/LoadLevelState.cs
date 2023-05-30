using Infrastructure.Factory;
using Infrastructure.GameOption.LevelData;
using Infrastructure.Services.StaticData;
using Infrastructure.UI.Factory;
using Opsive.UltimateCharacterController.Camera;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.StateMachine.State
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly Infrastructure.SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly IUIFactory _uiFactory;
        private readonly IStateMachineBase _characterStateMachine;

        public LoadLevelState(GameStateMachine stateMachine, Infrastructure.SceneLoader sceneLoader
            , IGameFactory gameFactory, IStaticDataService staticDataService
            , IUIFactory uiFactory, IStateMachineBase characterStateMachine)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _staticDataService = staticDataService;
            _uiFactory = uiFactory;
            _characterStateMachine = characterStateMachine;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            LevelStaticData levelData = _staticDataService.ForLevel(SceneManager.GetActiveScene().name);
            GameObject hero = _gameFactory.CreateHero(levelData.InitialHeroPosition);
            Camera.main.GetComponent<CameraController>().Character = hero;
            _gameFactory.CreateHud();
            _uiFactory.CreateUIRoot();
            _stateMachine.Enter<GameLoopState>();
        }
    }
}