using System.Collections.Generic;
using UnityEngine;
using Upgrades;

namespace Ships
{
    public class PlayerTurretLink : MonoBehaviour
    {
        [field: SerializeField]
        public FiveBoolUpgradeData Upgrade { get; private set; }
        
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

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                
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