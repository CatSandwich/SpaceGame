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
    }
}
