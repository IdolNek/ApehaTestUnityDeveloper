using UnityEngine;

namespace Character.Enemy
{
    public class AttackTrigger : MonoBehaviour
    {
        [SerializeField] private MeleeAttack _meleeAttack;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out Player player))
                _meleeAttack.SetTarget(player);
        }
    }
}