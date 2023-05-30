using UnityEngine;
using UnityEngine.AI;

namespace Character.Enemy
{
    public class EnemyAnimator : AnimatorBase
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private float magnitude;
        protected override void Update()
        {
            magnitude = _agent.velocity.magnitude;
            if(magnitude > 1 ) _animator.SetFloat(_move, magnitude);
            else _animator.SetFloat(_move, 0f);

        }
    }
}
