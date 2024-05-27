using UnityEngine;

namespace Helpers
{
    public static class VectorExtensions
    {
        public static Vector3 WithX(this Vector3 v3, float x) => new(x, v3.y, v3.z);
        public static Vector3 WithY(this Vector3 v3, float y) => new(v3.x, y, v3.z);
        public static Vector3 WithZ(this Vector3 v3, float z) => new(v3.x, v3.y, z);
    }
}