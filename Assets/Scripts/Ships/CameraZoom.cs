using Helpers;
using UnityEngine;

namespace Ships
{
    public class CameraZoom : MonoBehaviour
    {
        private static int MapBit => LayerMask.GetMask("Map");
        
        [field: SerializeField]
        public float MaxZoom { get; private set; }

        [field: SerializeField]
        public float MinZoom { get; private set; }
        
        [field: SerializeField]
        public float MapThreshold { get; private set; }

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

            int mask = ~0;

            if (Zoom < MapThreshold)
            {
                mask -= MapBit;
            }
            
            Camera.cullingMask = mask;
        }
    }
}
