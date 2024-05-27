using Helpers;
using UnityEngine;

namespace Ships
{
    public class CameraZoom : MonoBehaviour
    {
        [field: SerializeField]
        public float MaxZoom { get; private set; }

        [field: SerializeField]
        public float MinZoom { get; private set; }

        [field: SerializeField]
        private Camera Camera { get; set; }

        private float Zoom
        {
            get => Camera.transform.position.y;
            set => Camera.transform.position = Camera.transform.position.WithY(value);
        }

        private void Update()
        {
            Zoom = Mathf.Clamp(Zoom - Input.mouseScrollDelta.y, MinZoom, MaxZoom);
        }
    }
}
