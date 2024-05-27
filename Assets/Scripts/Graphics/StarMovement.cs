using UnityEngine;

namespace Graphics
{
    public class StarMovement : MonoBehaviour
    {
        public GameObject ship;

        // Update is called once per frame
        void Update()
        {
            transform.position = ship.transform.position;
        }
    }
}
