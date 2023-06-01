using Infrastructure.GameOption.EnemyData;
using UnityEngine;

namespace Infrastructure.GameOption.LevelData
{
    public class EnemySpawnerMarker: MonoBehaviour
    {
        [SerializeField] private EnemyTypeId _enemyEnemyId;
        public EnemyTypeId EnemyId => _enemyEnemyId;

    }
}