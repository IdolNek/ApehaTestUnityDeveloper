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
            _gameFactory.CreateCamera();
            _gameFactory.CreateHud();
            _uiFactory.CreateUIRoot();
            InitLevelEnemySpawner();
            _stateMachine.Enter<GameLoopState>();
        }

        private void InitLevelEnemySpawner()
        {
            string sceneKey = SceneManager.GetActiveScene().name;
            LevelStaticData levelData = _staticDataService.ForLevel(sceneKey);
            foreach (EnemySpawnerData spawnerData in levelData.EnemySpawnersData)
            {
                GameObject enemy = _gameFactory.CreateEnemy(spawnerData.EnemyTypeId, spawnerData.Position);
            }
        }
    }
}