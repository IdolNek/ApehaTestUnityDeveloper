using Infrastructure.GameOption.EnemyData;
using UnityEngine;

namespace Infrastructure.GameOption.LevelData
{
    public class EnemySpawner: MonoBehaviour
    {
        [SerializeField] private EnemyTypeId _enemyTypeId;
        private string _id;
        private void Awake()
        {
            _id = GetComponent<UniqueId>().Id;
        }
    }
}