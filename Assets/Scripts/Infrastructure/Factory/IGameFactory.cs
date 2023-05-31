using Infrastructure.GameOption.EnemyData;
using Infrastructure.Services;
using SpawnPool;
using UnityEngine;

namespace Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject Player { get; }
        GameObject CreateEnemy(EnemyTypeId enemyTypeId);
        GameObject CreateHero(Vector3 at);
        GameObject CreateHud();
        GameObject CreateMoney(Vector3 position);
        void CreateCamera();
    }
}