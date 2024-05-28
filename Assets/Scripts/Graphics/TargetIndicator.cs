using Helpers;
using Ships;
using UnityEngine;

namespace Graphics
{
    public class TargetIndicator : MonoBehaviour
    {
        public LaserTarget target;
        public GameObject parent;

        // Update is called once per frame
        void Update()
        {
            var targetPos = target.transform.position;
            var forward = transform.position - targetPos;
            transform.rotation = Quaternion.LookRotation(Vector3.up, forward);

            float length = Vector3.Magnitude(forward);
            transform.localScale = transform.localScale.WithY(length);
            transform.localPosition = -forward / 2 + parent.transform.position;
        }
    }
}
