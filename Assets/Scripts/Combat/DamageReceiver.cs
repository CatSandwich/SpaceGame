using UnityEngine;
using UnityEngine.Events;

namespace Combat
{
    public class DamageReceiver : MonoBehaviour
    {
        [field: SerializeField]
        public UnityEvent<float> TakeDamage { get; private set; }
        
        [field: SerializeField]
        public bool Verbose { get; private set; }

        public void Damage(float damage)
        {
            TakeDamage.Invoke(damage);

            if (Verbose)
            {
                Debug.Log($"[DamageReceiver] '{name}' took {damage} damage.");
            }
        }
    }
}
