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
        public float MapThreshold { get; private set; }

        [field: SerializeField]
        private Camera Camera { get; set; }
        
        private float TargetZoom { get; set; }
        private Coroutine ZoomCoroutine { get; set; }

        private void Start()
        {
            TargetZoom = Zoom;
        }

        private void Update()
        {
            if (Input.mouseScrollDelta != Vector2.zero)
            {
                if (ZoomCoroutine != null)
                {
                    StopCoroutine(ZoomCoroutine);
                }
                
                TargetZoom = Mathf.Clamp(TargetZoom - Input.mouseScrollDelta.y * ZoomSpeed, MinZoom, MaxZoom);
                ZoomCoroutine = StartCoroutine(ZoomRoutine(TargetZoom, 0.2f));
            }

            UpdateCameraPosition();
            UpdateMapLayer();
        }

        private IEnumerator ZoomRoutine(float targetZoom, float duration)
        {
            float startZoom = Zoom;
            float startTime = Time.time;
            float endTime = startTime + duration;

            while (Time.time < endTime)
            {
                float t = 1 - (endTime - Time.time) / duration;
                Zoom = Mathf.SmoothStep(startZoom, targetZoom, t);
                yield return null;
            }

            Zoom = targetZoom;
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
