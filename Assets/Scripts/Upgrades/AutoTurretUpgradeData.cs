using System;
using UnityEngine;

namespace Upgrades
{
    [CreateAssetMenu(menuName = "Upgrade/AutoTurret")]
    public class AutoTurretUpgradeData : UpgradeData<AutoTurretUpgradeData.AutoTurretData>
    {
        [Serializable]
        public struct AutoTurretData
        {
            public int MaxTargets;
            public float FireRate;
            public float Damage;
        }
    }
}
