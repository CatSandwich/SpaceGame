using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterHandler : MonoBehaviour
{
    public List<GameObject> thrusterPositions;
    public GameObject thrusterAsset;
    List<ParticleSystem> thrusters = new List<ParticleSystem>();

    void Start()
    {
        thrusterPositions.ForEach(x => {
            var thruster = Instantiate(thrusterAsset, transform);
            thruster.transform.position = x.transform.position;
            thrusters.Add(thruster.GetComponent<ParticleSystem>()); 
        });
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

    [System.Obsolete]
    void SetThrusterOn(bool on)
    {
        thrusters.ForEach(x => {
            x.enableEmission = on;
        });
    }
}
