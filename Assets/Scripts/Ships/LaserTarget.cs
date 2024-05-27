using Combat;
using UnityEngine;
using UnityEngine.Events;

namespace Ships
{
    public class LaserTarget : MonoBehaviour
    {
        [field: SerializeField]
        public DamageReceiver Receiver { get; private set; }

        [field: SerializeField]
        public UnityEvent Destroyed { get; private set; }
        
        public void Damage(float damage)
        {
            Receiver.Damage(damage);
        }

        private void OnDestroy()
        {
            Destroyed.Invoke();
        }
    }
}
