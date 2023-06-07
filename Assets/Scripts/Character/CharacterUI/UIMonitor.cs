using Opsive.UltimateCharacterController.Traits;
using UnityEngine;
using EventHandler = Opsive.Shared.Events.EventHandler;

namespace Character.CharacterUI
{
    public class UIMonitor : MonoBehaviour
    {
        private const string HealthAttributeName = "Health";
        private const string EventName = "OnHealthDamage";
        
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private AttributeManager _attributeManager;
        [SerializeField] private GameObject _character;
        private float _maxHealthValue;
        private float _currentHealthValue;

        private void OnEnable()
        {
            EventHandler.RegisterEvent<float, Vector3, Vector3, GameObject,
                Collider>(_character, EventName, OnDamage);
            _maxHealthValue = _attributeManager.GetAttribute(HealthAttributeName).MaxValue;
        }

        private void OnDamage(float count, Vector3 arg2, Vector3 arg3, GameObject arg4, Collider arg5)
        {
            _currentHealthValue = _attributeManager.GetAttribute(HealthAttributeName).Value;
            _healthBar.SetValue(_currentHealthValue, _maxHealthValue);
        }
    }
}