using Helpers;
using UnityEngine;

namespace Ships
{
    public class ZoomMovement : MonoBehaviour
    {
        [field: SerializeField]
        public float MaxSpeed { get; private set; }

        [field: SerializeField]
        public float Acceleration { get; private set; }

        [field: SerializeField]
        public float Deceleration { get; private set; }

        [field: SerializeField]
        public float AngularVelocity { get; private set; }
    
        [field: SerializeField]
        private Rigidbody Rigidbody { get; set; }

        public float Speed => Rigidbody.velocity.magnitude;

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Decelerate();
            }
            else if (Input.GetMouseButton(1))
            {
                RotateToCursor();
                Accelerate();
            }
        }

        private void Decelerate()
        {
            float newSpeed = Speed + Deceleration * Time.deltaTime;

            if (newSpeed < 0)
            {
                newSpeed = 0;
            }

            Rigidbody.velocity = transform.forward * newSpeed;
        }

        private void RotateToCursor()
        {
            Vector3 cursorWorldPosition = Camera.main.GetCursorWorldPosition();
            Vector3 forward = cursorWorldPosition - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(forward, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, AngularVelocity * Time.deltaTime);
        }

        private void Accelerate()
        {
            float newSpeed = Speed + Acceleration * Time.deltaTime;

            if (newSpeed > MaxSpeed)
            {
                newSpeed = MaxSpeed;
            }

            Rigidbody.velocity = transform.forward * newSpeed;
        }
    }
}
