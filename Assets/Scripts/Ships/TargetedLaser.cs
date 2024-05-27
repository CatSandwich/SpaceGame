using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Upgrades;

namespace Ships
{
    public class TargetedLaser : MonoBehaviour
    {
        [field: SerializeField]
        public TargetedLaserUpgradeData Upgrade { get; private set; }
        
        [field: SerializeField]
        public bool Verbose { get; private set; }

        [field: SerializeField]
        public UnityEvent<LaserTarget> TargetHit { get; private set; }

        [field: SerializeField]
        public UnityEvent<LaserTarget> TargetAcquired { get; private set; }

        [field: SerializeField]
        public UnityEvent<LaserTarget> TargetLost { get; private set; }
        
        private List<LaserTarget> Targets { get; } = new();

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f / Upgrade.CurrentValue.FireRate);

                foreach (LaserTarget target in Targets)
                {
                    target.Damage(Upgrade.CurrentValue.Damage);
                    TargetHit.Invoke(target);
                    
                    LogVerbose($"Hit '{target.gameObject.name}' for {Upgrade.CurrentValue.Damage}.");
                }
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {                
            if (other.gameObject.TryGetComponent(out LaserTarget target))
            {
                if (Targets.Count < Upgrade.CurrentValue.MaxTargets)
                {            
                    AddTarget(target);
                }
                else
                {
                    LogVerbose("Target found, but laser is busy.");
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out LaserTarget target))
            {
                RemoveTarget(target);
            }
        }

        private void AddTarget(LaserTarget target)
        {
            Targets.Add(target);
            target.Destroyed.AddListener(() => RemoveTarget(target));
            
            TargetAcquired.Invoke(target);
            
            LogVerbose($"Target acquired: {target.gameObject.name}.");
        }

        private void RemoveTarget(LaserTarget target)
        {
            Targets.Remove(target);
            
            TargetLost.Invoke(target);
            
            LogVerbose($"Target lost: {target.gameObject.name}.");
        }

        private void LogVerbose(string message)
        {
            if (!Verbose)
            {
                return;
            }
            
            Debug.Log($"[{nameof(TargetedLaser)}] {message}");
        }
    }
}
