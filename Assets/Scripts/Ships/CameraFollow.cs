using Helpers;
using UnityEngine;

namespace Ships
{
    public class CameraFollow : MonoBehaviour
    {
        [field: SerializeField]
        public Transform Target { get; private set; }

        void Update()
        {
            transform.position = Target.position.WithY(transform.position.y);
        }
    }
}
