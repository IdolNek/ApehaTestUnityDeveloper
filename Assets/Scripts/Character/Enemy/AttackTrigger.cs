using UnityEngine;

namespace Character.Enemy
{
    public class AttackTrigger : MonoBehaviour
    {
        [SerializeField] private MeleeAttack _meleeAttack;
        private SphereCollider _sphereCollider;

        private void Awake() => 
            _sphereCollider = GetComponent<SphereCollider>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out Player player))
                _meleeAttack.SetTarget(player);
        }

        public void SetAttackRadiusTrigger(float enemyDataAttackRange) => 
            _sphereCollider.radius = enemyDataAttackRange;
    }
}