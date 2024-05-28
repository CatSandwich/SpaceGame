using System.Collections.Generic;
using Ships;
using UnityEngine;

namespace Graphics
{
    public class TargetIndicatorHandler : MonoBehaviour
    {
        public TargetIndicator indicatorPrefab;
        Dictionary<LaserTarget, TargetIndicator> targets = new Dictionary<LaserTarget, TargetIndicator>();

        public void AddTarget(LaserTarget target)
        {
            TargetIndicator indicator = Instantiate(indicatorPrefab);
            indicator.target = target;
            indicator.parent = gameObject;
            targets.Add(target, indicator);
        }

        public void RemoveTarget(LaserTarget target)
        {
            Destroy(targets[target].gameObject);
            targets.Remove(target);
        }

        public void HitTarget(LaserTarget target)
        {
            var indicator = targets[target];
            // DO SOMETHING!!!
        }
    }
}
