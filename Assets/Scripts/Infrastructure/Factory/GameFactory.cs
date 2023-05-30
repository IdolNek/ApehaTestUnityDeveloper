using Character;
using Character.Enemy;
using Infrastructure.GameOption.EnemyData;
using Infrastructure.GameOption.LevelData;
using Infrastructure.GameOption.Player;
using Infrastructure.Services.Asset;
using Infrastructure.Services.PlayerProgress;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.Windows;
using Infrastructure.UI.Factory;
using SpawnPool;
using UI;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {

        private readonly IAssetService _asset;
        private readonly IStaticDataService _staticData;
        private readonly IProgressService _progress;
        private readonly IWindowsService _windowsService;
        private readonly IUIFactory _uIFactory;
        private GameObject _player;
        private EnemySpawner _spawner;

        public GameObject Player => _player;
        public EnemySpawner Spawner => _spawner;

        public GameFactory(IAssetService asset, IStaticDataService staticData,
            IProgressService progress, IWindowsService windowsService, IUIFactory uIFactory)
        {
            _asset = asset;
            _staticData = staticData;
            _progress = progress;
            _windowsService = windowsService;
            _uIFactory = uIFactory;
        }
        public GameObject CreateHero(Vector3 at)
        {
            PlayerStaticData playerData = _staticData.PlayerConfig;
            _player = Object.Instantiate(playerData.PlayerPrefab, at, Quaternion.identity);
            return _player;
        }
        public GameObject CreateHud()
        {
            GameObject hud = _asset.Instantiate(AssetPath.HUDPath);
            return hud;
        }

        public void CreateSpawner(EnemySpawnStaticData enemySpawnerStaticData)
        {
            _spawner = Object.Instantiate(enemySpawnerStaticData.SpawnPrefab).GetComponent<EnemySpawner>();
            _spawner.Construct(this, enemySpawnerStaticData);
            _spawner.Initialize();

        }

        public GameObject CreateEnemy(EnemyTypeId enemyTypeId)
        {
            EnemyStaticData enemydata = _staticData.ForEnemy(enemyTypeId);
            string sceneKey = SceneManager.GetActiveScene().name;
            LevelStaticData levelData = _staticData.ForLevel(sceneKey);
            GameObject enemy = Object.Instantiate(enemydata.EnemyPrefab);
            enemy.GetComponent<MoveEnemy>().Construct(_player.transform);
            enemy.GetComponent<Health>().Initialize(enemydata.Hp);
            enemy.GetComponent<Attack>().Initialize(enemydata.Damage, enemydata.AttackCountDown);
            MoneySpawn moneySpawn = enemy.GetComponent<MoneySpawn>();
            moneySpawn.Initialize(enemydata.MoneyCount);
            moneySpawn.Construct(this);
            enemy.GetComponent<NavMeshAgent>().speed = enemydata.MoveSpeed;
            enemy.GetComponent<GenerateRandomPointInAttackArea>().Initialize(levelData.EnemySpawnAreaCenter
                , levelData.EnemySpawnAreaSize);
            return enemy;
        }        
        public GameObject CreateMoney(Vector3 position)
        {
            var money = _asset.Instantiate(AssetPath.Money, position);
            return money;
        }        
    }
}