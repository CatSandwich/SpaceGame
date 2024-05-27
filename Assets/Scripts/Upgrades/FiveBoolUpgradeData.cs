using System;
using UnityEngine;

namespace Upgrades
{
    [CreateAssetMenu(menuName = "Upgrade/FiveBool")]
    public class FiveBoolUpgradeData : UpgradeData<FiveBoolUpgradeData.FiveBool>
    {
        [Serializable]
        public struct FiveBool
        {
            public bool B1;
            public bool B2;
            public bool B3;
            public bool B4;
            public bool B5;
        }
    }
}
