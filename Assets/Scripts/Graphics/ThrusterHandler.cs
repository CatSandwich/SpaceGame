using System.Collections.Generic;
using UnityEngine;

namespace Graphics
{
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
#pragma warning disable CS0618 // Type or member is obsolete
                x.trail.enableEmission = on;
#pragma warning restore CS0618 // Type or member is obsolete
                x.flare.SetActive(on);
            });
        }
    }
}
