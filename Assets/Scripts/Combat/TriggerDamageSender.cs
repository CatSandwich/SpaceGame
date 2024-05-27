using UnityEngine;

namespace Combat
{
    public class TriggerDamageSender : MonoBehaviour
    {
        [field: SerializeField]
        public float Damage { get; private set; }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out DamageReceiver receiver))
            {
                receiver.Damage(Damage);
            }
        }

        private void OnValidate()
        {
            if (!FindObjectOfType<Collider>())
            {
                Debug.LogError($"No 3D collider on TriggerDamageSender '{name}'.", this);
            }
        }
    }
}
