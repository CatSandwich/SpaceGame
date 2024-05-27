using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterHandler : MonoBehaviour
{
    public List<GameObject> thrusterPositions;
    public ThrusterTrail thrusterAsset;
    List<ThrusterTrail> thrusters = new List<ThrusterTrail>();

    void Start()
    {
        thrusterPositions.ForEach(x => {
            var thruster = Instantiate(thrusterAsset, transform);
            thruster.transform.position = x.transform.position;
            thrusters.Add(thruster); 
        });

        SetThrusterOn(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            SetThrusterOn(true);
        }
        if (Input.GetMouseButtonUp(1)) {
            SetThrusterOn(false);
        }
    }

    void SetThrusterOn(bool on)
    {
        thrusters.ForEach(x => {
            x.trail.enableEmission = on;
            x.flare.SetActive(on);
        });
    }
}
