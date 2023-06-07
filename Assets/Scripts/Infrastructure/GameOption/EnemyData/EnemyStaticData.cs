using UnityEngine;

namespace Infrastructure.GameOption.EnemyData
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "StaticData/Enemy")]
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyTypeId EnemyTypeId;
        [Range(1, 100)]
        public int Hp;
        [Range(1, 30)]
        public int Damage;
        [Range(3, 15)] 
        public float AttackRange;
        [Range(0.1f, 100)]
        public float StopAttackRange;
        [Range(0.1f, 5)]
        public float AttackCountDown;

        public int MoneyCount;

        public GameObject EnemyPrefab;
    }
}