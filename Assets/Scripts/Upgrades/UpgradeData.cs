using System;
using UnityEngine;

namespace Upgrades
{
    public class UpgradeData<T> : UpgradeData where T : struct
    {
        [field: SerializeField]
        public Upgrade[] Upgrades { get; private set; }
        
        public T CurrentValue => Upgrades[Level].Value;

        public override string CurrentUpgradeName => Upgrades[Level].Name;

        public override string NextUpgradeName => !IsMaxed
            ? Upgrades[Level + 1].Name
            : throw new InvalidOperationException("Cannot get the next upgrade name of maxed upgrade.");

        public override int CostToUpgrade => !IsMaxed
             ? Upgrades[Level + 1].Cost
             : throw new InvalidOperationException("Cannot get the cost of maxed upgrade.");
        
        public override bool IsMaxed => Level == Upgrades.Length - 1;

        [Serializable]
        public class Upgrade
        {
            [field: SerializeField]
            public string Name { get; private set; }

            [field: SerializeField]
            public int Cost { get; private set; }

            [field: SerializeField]
            public T Value { get; private set; }
        }
    }

    public abstract class UpgradeData : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField] 
        public string Description { get; private set; }

        [field: SerializeField]
        public string Key { get; private set; }
        
        public abstract string CurrentUpgradeName { get; }
        public abstract string NextUpgradeName { get; }
        public abstract int CostToUpgrade { get; }
        public abstract bool IsMaxed { get; }
        
        public int Level
        {
            get => PlayerPrefs.GetInt(Key, 0);
            set => PlayerPrefs.SetInt(Key, value);
        }
    }
}