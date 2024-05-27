using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterHandler : MonoBehaviour
{
    public List<GameObject> thrusterPositions;
    public GameObject thrusterAsset;
    List<GameObject> thrusters = new List<GameObject>();

    void Start()
    {
        thrusterPositions.ForEach(x => {
            var thruster = Instantiate(thrusterAsset, transform);
            thruster.transform.position = x.transform.position;
            thrusters.Add(thruster); 
        });
    }

    void Update()
    {
        
    }
}
