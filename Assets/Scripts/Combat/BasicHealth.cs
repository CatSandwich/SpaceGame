using UnityEngine;

namespace Combat
{
    public class BasicHealth : MonoBehaviour
    {
        [field: SerializeField]
        public float MaxHealth { get; private set; }
        public float Health { get; private set; }

        private void Start()
        {
            Health = MaxHealth;
        }

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
