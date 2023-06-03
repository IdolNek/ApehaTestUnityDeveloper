using Opsive.UltimateCharacterController.Character;
using Opsive.UltimateCharacterController.Character.Abilities;
using Opsive.UltimateCharacterController.Character.Abilities.AI;
using Opsive.UltimateCharacterController.Character.Abilities.Items;
using UnityEngine;

namespace Character.Enemy
{
    public class MeleeAttack : MonoBehaviour
    {
        [SerializeField] private UltimateCharacterLocomotion _characterLocomotion;
        [SerializeField] private LocalLookSource _localLookSource;
        [SerializeField] private float _immediateAttackDistance = 1.5f;
        [SerializeField] private float _stopMoveToTarget = 2.5f;
        [SerializeField] private EnemyAttackState _attackState;
        private Transform _target;
        private float _attackRange;
        private float _attackTimeReload;
        private float _currenAttackTimeReload;
        private Use _useAbility;
        private NavMeshAgentMovement _meshAgentMovement;
        private RotateTowards _rotateTowards;
        private bool _canAttack = false;
        private bool _isAttackState = false;

        public void Construct(float attackRange, float attackTimeReload)
        {
            _attackRange = attackRange;
            _attackTimeReload = attackTimeReload;
        }

        private void Start()
        {
            _useAbility = _characterLocomotion.GetAbility<Use>();
            _meshAgentMovement = _characterLocomotion.GetAbility<NavMeshAgentMovement>();
            _rotateTowards = _characterLocomotion.GetAbility<RotateTowards>();
        }

        private void Update()
        {
            _currenAttackTimeReload += Time.deltaTime;
            if (_currenAttackTimeReload > _attackTimeReload) _canAttack = true;
            if (!_canAttack) return;
            if (_target == null) return;
            float targetDistance = Vector3.Distance(transform.position, _target.position);
            if (targetDistance < _immediateAttackDistance) Attack();
            if (targetDistance > _attackRange) CancelAttack();
            if (targetDistance < _stopMoveToTarget) AttackState();
        }

        private void Attack()
        {
            _characterLocomotion.TryStartAbility(_useAbility);
            _canAttack = false;
            _currenAttackTimeReload = 0;
        }

        private void AttackState()
        {
            if(_isAttackState) return;
            _isAttackState = true;
            _attackState.enabled = true;
        }

        private void CancelAttack()
        {
            _attackState.enabled = false;
            _meshAgentMovement.SetDestination(_target.position);
            _isAttackState = false;
        }

        public void SetTarget(Player player)
        {
            _rotateTowards.Target = player.transform;
            _localLookSource.Target = player.transform;
            _target = player.transform;
            _meshAgentMovement.SetDestination(_target.position);
        }
    }
}