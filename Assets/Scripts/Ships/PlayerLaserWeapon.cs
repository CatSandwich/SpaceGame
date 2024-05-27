using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Upgrades;

namespace Ships
{
    public class PlayerLaserWeapon : MonoBehaviour
    {
        [field: SerializeField]
        public FiveBoolUpgradeData Upgrade { get; private set; }
        
        [field: SerializeField]
        public Rigidbody LaserPrefab { get; private set; }
        
        [field: SerializeField]
        public Rigidbody Self { get; private set; }
        
        [field: SerializeField]
        public float LaserSpeed { get; private set; }
        
        [field: SerializeField]
        public float FireRate { get; private set; }
        
        [field: SerializeField]
        public Transform Turret1 { get; private set; }
        
        [field: SerializeField]
        public Transform Turret2 { get; private set; }
        
        [field: SerializeField]
        public Transform Turret3 { get; private set; }
        
        [field: SerializeField]
        public Transform Turret4 { get; private set; }
        
        [field: SerializeField]
        public Transform Turret5 { get; private set; }

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitUntil(() => Input.GetMouseButton(0));
                Shoot();
                yield return new WaitForSeconds(1f / FireRate);
            }
        }

        private void Shoot()
        {
            foreach (Transform source in GetSourceTurrets())
            {
                Rigidbody laser = Instantiate(LaserPrefab, source.position, source.rotation);
                laser.velocity = transform.forward * LaserSpeed + Self.velocity;
                laser.gameObject.layer = LayerMask.NameToLayer("PlayerWeapon");
            }
        }

        private IEnumerable<Transform> GetSourceTurrets()
        {
            if (Upgrade.CurrentValue.B1)
            {
                yield return Turret1;
            }
            
            if (Upgrade.CurrentValue.B2)
            {
                yield return Turret2;
            }
            
            if (Upgrade.CurrentValue.B3)
            {
                yield return Turret3;
            }
            
            if (Upgrade.CurrentValue.B4)
            {
                yield return Turret4;
            }
            
            if (Upgrade.CurrentValue.B5)
            {
                yield return Turret5;
            }
        }
    }
}
