using Combat;
using UnityEngine;

namespace Ships
{
    public class LaserTarget : MonoBehaviour
    {
        [field: SerializeField]
        public DamageReceiver Receiver { get; private set; }
        
        public void Damage(float damage)
        {
            Receiver.Damage(damage);
        }
    }
}
