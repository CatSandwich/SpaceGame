using System;
using UnityEngine;

namespace Upgrades
{
    [CreateAssetMenu(menuName = "Upgrade/AutoTurret")]
    public class TargetedLaserUpgradeData : UpgradeData<TargetedLaserUpgradeData.TargetedLaserData>
    {
        [Serializable]
        public struct TargetedLaserData
        {
            public int MaxTargets;
            public float FireRate;
            public float Damage;
        }
    }
}
