using System.Collections;
using System.Collections.Generic;
using Ships;
using UnityEngine;

public class TargetIndicatorHandler : MonoBehaviour
{
    public GameObject ship;
    public TargetIndicator indicatorPrefab;
    Dictionary<LaserTarget, TargetIndicator> targets = new Dictionary<LaserTarget, TargetIndicator>();

    public void AddTarget(LaserTarget target)
    {
        TargetIndicator indicator = Instantiate(indicatorPrefab, transform);
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

    void Update()
    {
        transform.position = ship.transform.position;
    }
}
