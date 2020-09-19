using UnityEngine;


namespace DefaultNamespace.Ground
{
    public class RotateTrigger : MonoBehaviour
    {
        [SerializeField] private RotateDirection rotateDirection;
        private CurrentRotate currentRotate;
        
        private void Start()
        {
            currentRotate = transform.parent.GetComponent<CurrentRotate>();
        }

        private void OnTriggerEnter(Collider other)
        {
            currentRotate.Direction = rotateDirection;
            Debug.Log("Rotate to " + rotateDirection);
        }

        private void OnTriggerExit(Collider other)
        {
            currentRotate.Direction = RotateDirection.None;
            Debug.Log("Rotate to " + rotateDirection);
        }
    }
}