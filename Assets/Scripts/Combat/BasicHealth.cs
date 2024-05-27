using UnityEngine;

namespace Combat
{
    public class BasicHealth : MonoBehaviour
    {
        [field: SerializeField]
        public float Health { get; private set; }

        public void OnDamageReceived(float damage)
        {
            Health -= damage;

            if (Health <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
