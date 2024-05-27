using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Upgrades;

namespace Ships
{
    public class TargetedLaser : MonoBehaviour
    {
        [field: SerializeField]
        public TargetedLaserUpgradeData Upgrade { get; private set; }
        
        [field: SerializeField]
        public bool Verbose { get; private set; }
        
        private List<LaserTarget> Targets { get; } = new();

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f / Upgrade.CurrentValue.FireRate);

                foreach (LaserTarget target in Targets)
                {
                    target.Damage(Upgrade.CurrentValue.Damage);
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
                    Targets.Add(target);
                    LogVerbose($"Target acquired: {target.gameObject.name}.");
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
                Targets.Remove(target);
                LogVerbose($"Target lost: {target.gameObject.name}.");
            }
        }

        private void LogVerbose(string message)
        {
            if (!Verbose)
            {
                return;
            }
            
            Debug.Log($"[TargetedLaser] {message}");
        }
    }
}
