using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace.camera
{
    public class CameraMove : MonoBehaviour
    {
        [SerializeField] private MoveHero target;
        [SerializeField] private float speed;
        
        private Vector2 _differenceDistance;
        private Transform _targetTransform;

        private void Start()
        {
            _targetTransform = target.transform; 
            
            _differenceDistance.x = Mathf.Abs(_targetTransform.position.x - transform.position.x);
            _differenceDistance.y = Mathf.Abs(_targetTransform.position.z - transform.position.z);
        }

        private void Update()
        {
            MoveForward();
            MoveToTarget();
        }

        private void MoveForward()
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        private void MoveToTarget()
        {
            MoveDirection currentDirection = target.MoveDirection;

            if (target.IsMoved)
            {
                if (currentDirection == MoveDirection.Right)
                {
                    //Z +
                    float newPositionZ = _targetTransform.position.z - _differenceDistance.y;
                    transform.DOMoveZ(newPositionZ, 1f);
                }
                else if (currentDirection == MoveDirection.Left)
                {
                    //X -
                    float newPositionX = _targetTransform.position.x + _differenceDistance.x;
                    transform.DOMoveX(newPositionX, 1f);
                }
            }
        }
        

    }
}