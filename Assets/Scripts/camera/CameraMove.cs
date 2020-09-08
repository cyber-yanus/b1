using UnityEngine;

namespace DefaultNamespace.camera
{
    public class CameraMove : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float speed;
        
        private float _differenceDistance;

        private void Start()
        {
             
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            
        }

    }
}