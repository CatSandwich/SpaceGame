using UnityEngine;
using UnityEngine.Events;

namespace Combat
{
    public class TriggerDamageSender : MonoBehaviour
    {
        [field: SerializeField]
        public float Damage { get; private set; }

        [field: SerializeField]
        public UnityEvent<DamageDealtEventArgs> DamageDealt;

        public void Destroy(GameObject obj)
        {
            Object.Destroy(obj);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out DamageReceiver receiver))
            {
                receiver.Damage(Damage);
                
                DamageDealt.Invoke(new DamageDealtEventArgs
                {
                    Damage = Damage,
                    Receiver = receiver
                });
            }
        }

        public class DamageDealtEventArgs
        {
            public float Damage;
            public DamageReceiver Receiver;
        }
    }
}
