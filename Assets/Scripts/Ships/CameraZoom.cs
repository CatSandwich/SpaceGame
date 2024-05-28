using System.Collections;
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
        public float ZoomConvergence { get; private set; }
        
        [field: SerializeField]
        public float MapThreshold { get; private set; }

        [field: SerializeField]
        private Camera Camera { get; set; }
        
        private float TargetZoom { get; set; }

        private void Start()
        {
            TargetZoom = Zoom;
        }

        private void Update()
        {
            if (Input.mouseScrollDelta != Vector2.zero)
            {
                TargetZoom = Mathf.Clamp(TargetZoom - Input.mouseScrollDelta.y * ZoomSpeed, MinZoom, MaxZoom);
            }

            if (Mathf.Abs(Zoom - TargetZoom) < 0.00001)
            {
                Zoom = TargetZoom;
            }
            else
            {
                Zoom = Mathf.Lerp(Zoom, TargetZoom, Time.deltaTime * ZoomConvergence);
            }

            UpdateCameraPosition();
            UpdateMapLayer();
        }

        private void UpdateCameraPosition()
        {
            Camera.transform.position = Camera.transform.position.WithY(Mathf.Pow(10, Zoom));
        }

        private void UpdateMapLayer()
        {
            int mask = ~0;

            if (Zoom < MapThreshold)
            {
                mask -= MapBit;
            }
            
            Camera.cullingMask = mask;
        }
    }
}
