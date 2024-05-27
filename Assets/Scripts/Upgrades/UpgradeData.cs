using System;
using UnityEngine;

namespace Upgrades
{
    public class UpgradeData<T> : UpgradeData where T : struct
    {
        [field: SerializeField]
        public Upgrade[] Upgrades { get; private set; }
        
        public T CurrentValue => Upgrades[Level].Value;

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
        
        public int Level
        {
            get => PlayerPrefs.GetInt(Key, 0);
            set => PlayerPrefs.SetInt(Key, value);
        }
    }
}