using UnityEngine;

namespace Helpers
{
    public static class CameraExtensions
    {
        public static Vector3 GetCursorWorldPosition(this Camera camera, int y = 0)
        {
            Plane xz = new(Vector3.up, new Vector3(0, y, 0));
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            xz.Raycast(ray, out float distance);

            return ray.GetPoint(distance);
        }
    }
}
