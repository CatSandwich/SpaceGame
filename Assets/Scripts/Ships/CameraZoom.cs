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
        public float Zoom { get; private set; }
        
        [field: SerializeField]
        public float ZoomSpeed { get; private set; }
        
        [field: SerializeField]
        public float MapThreshold { get; private set; }

        [field: SerializeField]
        private Camera Camera { get; set; }

        private void Update()
        {
            Zoom = Mathf.Clamp(Zoom - Input.mouseScrollDelta.y * ZoomSpeed, MinZoom, MaxZoom);

            Camera.transform.position = Camera.transform.position.WithY(Mathf.Pow(10, Zoom));

            int mask = ~0;

            if (Zoom < MapThreshold)
            {
                mask -= MapBit;
            }
            
            Camera.cullingMask = mask;
        }
    }
}
