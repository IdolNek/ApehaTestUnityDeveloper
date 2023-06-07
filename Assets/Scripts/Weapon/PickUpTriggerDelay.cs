using System.Collections;
using UnityEngine;

namespace Weapon
{
    [RequireComponent(typeof(SphereCollider))]
    public class PickUpTriggerDelay : MonoBehaviour
    {
        [SerializeField] private SphereCollider _sphereCollider;
        [SerializeField] private float _triggerTimeDelay = 2f;

        private void Start()
        {
            _sphereCollider = GetComponent<SphereCollider>();
            StartCoroutine(TriggerDelay());
        }

        private IEnumerator TriggerDelay()
        {
            yield return new WaitForSeconds(_triggerTimeDelay);
            _sphereCollider.enabled = true;
        }
    }
}