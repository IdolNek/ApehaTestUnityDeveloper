using Character.CharacterUI;
using Character.Enemy;
using Infrastructure.GameOption.EnemyData;
using Infrastructure.GameOption.LevelData;
using Infrastructure.GameOption.Player;
using Infrastructure.Services.Asset;
using Infrastructure.Services.PlayerProgress;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.Windows;
using Infrastructure.UI.Factory;
using Opsive.UltimateCharacterController.Camera;
using Opsive.UltimateCharacterController.Items.Actions;
using Opsive.UltimateCharacterController.Traits;
using SpawnPool;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private const string HealthAttributeName = "Health";

        private readonly IAssetService _asset;
        private readonly IStaticDataService _staticData;
        private readonly IProgressService _progress;
        private readonly IWindowsService _windowsService;
        private readonly IUIFactory _uIFactory;
        private GameObject _player;

        public GameObject Player => _player;

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
            _player.GetComponent<AttributeManager>().GetAttribute(HealthAttributeName).MaxValue = playerData.Hp;
            return _player;
        }
        public GameObject CreateHud()
        {
            GameObject hud = _asset.Instantiate(AssetPath.HUDPath);
            return hud;
        }

        public GameObject CreateEnemy(EnemyTypeId enemyTypeId, Vector3 at)
        {
            EnemyStaticData enemyData = _staticData.ForEnemy(enemyTypeId);
            GameObject enemy = Object.Instantiate(enemyData.EnemyPrefab, at, Quaternion.identity);
            enemy.GetComponent<MeleeAttack>().Construct(enemyData.StopAttackRange , enemyData.AttackCountDown);
            enemy.GetComponent<AttributeManager>().GetAttribute(HealthAttributeName).MaxValue = enemyData.Hp;
            enemy.GetComponentInChildren<MeleeWeapon>().DamageAmount = enemyData.Damage;
            enemy.GetComponentInChildren<AttackTrigger>().SetAttackRadiusTrigger(enemyData.AttackRange);
            enemy.GetComponent<UIMonitor>().Initialize();
            MoneySpawn moneySpawn = enemy.GetComponent<MoneySpawn>();
            moneySpawn.Initialize(enemyData.MoneyCount);
            moneySpawn.Construct(this);
            return enemy;
        }        
        public GameObject CreateMoney(Vector3 position)
        {
            GameObject money = _asset.Instantiate(AssetPath.Money, position);
            return money;
        }

        public void CreateCamera()
        {
            GameObject mainCamera = _asset.Instantiate((AssetPath.MainCamera));
            mainCamera.GetComponent<CameraController>().Character = _player;
        }
    }
}