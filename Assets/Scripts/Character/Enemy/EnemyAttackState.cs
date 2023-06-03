using Opsive.UltimateCharacterController.Character;
using Opsive.UltimateCharacterController.Character.Abilities.AI;
using Opsive.UltimateCharacterController.Character.Abilities.Items;
using UnityEngine;

namespace Character.Enemy
{
    public class EnemyAttackState : MonoBehaviour
    {
        [SerializeField] private UltimateCharacterLocomotion _characterLocomotion;
        [SerializeField] private float _rangeMoveDistance;
        [SerializeField] private float _minTimeInOnePlace;
        [SerializeField] private float _maxTimeInOnePlace;
        private Vector3 _targetPosition;
        private bool _isMoving;
        private NavMeshAgentMovement _meshAgentMovement;
        private Aim _aim;
        private float _currentTimeInOnePlace;
        private float _chooseTimeInOnePlace;

        private void OnEnable()
        {
            _meshAgentMovement = _characterLocomotion.GetAbility<NavMeshAgentMovement>();
            _aim = _characterLocomotion.GetAbility<Aim>();
            SetMoveState();
        }

        private void Update()
        {
            _currentTimeInOnePlace += Time.deltaTime;
            if (IsTarget() && _isMoving) SetStopState();
            if (_isMoving) return;
            if (_currentTimeInOnePlace > _chooseTimeInOnePlace) SetMoveState();
        }

        private void SetMoveState()
        {
            _isMoving = true;
            _characterLocomotion.TryStopAbility(_aim);
            _targetPosition = GetRandomTargetPosition();
            _meshAgentMovement.SetDestination(_targetPosition);
        }

        private Vector3 GetRandomTargetPosition()
        {
            const int convertToRadius = 2;
            var targetXPosition = transform.position.x + Random.Range(-_rangeMoveDistance / convertToRadius,
                _rangeMoveDistance / convertToRadius);
            var targetZPosition = transform.position.z + Random.Range(-_rangeMoveDistance / convertToRadius,
                _rangeMoveDistance / convertToRadius);
            return new Vector3(targetXPosition, transform.position.y, targetZPosition);
        }

        private void SetStopState()
        {
            _isMoving = false;
            _characterLocomotion.TryStartAbility(_aim);
            _currentTimeInOnePlace = 0f;
            _chooseTimeInOnePlace = Random.Range(_minTimeInOnePlace, _maxTimeInOnePlace);
        }

        private bool IsTarget()
        {
            float distance = Vector3.Distance(transform.position, _targetPosition);
            const float objectNearTarget = 0.2f;
            return distance < objectNearTarget;
        }
    }
}