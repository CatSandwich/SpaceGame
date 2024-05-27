using UnityEngine;

namespace Helpers
{
    public static class GameObjectExtensions
    {
        public static void SetLayer(this GameObject obj, int layer, bool recursive = false)
        {
            obj.layer = layer;

            if (recursive)
            {
                foreach (Transform child in obj.transform)
                {
                    child.gameObject.SetLayer(layer, true);
                }
            }
        }
    }
}
