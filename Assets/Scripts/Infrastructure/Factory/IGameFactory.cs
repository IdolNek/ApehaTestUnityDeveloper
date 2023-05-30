using Infrastructure.GameOption.EnemyData;
using Infrastructure.Services;
using SpawnPool;
using UnityEngine;

namespace Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        EnemySpawner Spawner { get; }
        GameObject Player { get; }
        GameObject CreateEnemy(EnemyTypeId enemyTypeId);
        GameObject CreateHero(Vector3 at);
        GameObject CreateHud();
        void CreateSpawner(EnemySpawnStaticData enemySpawnerStaticData);
        GameObject CreateMoney(Vector3 position);
    }
}