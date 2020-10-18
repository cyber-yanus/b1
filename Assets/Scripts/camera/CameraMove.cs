using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace.camera
{
    public class CameraMove : MonoBehaviour
    {
        [SerializeField] private MoveHero target;
        
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
            MoveToTarget();
        }
        
        private void MoveToTarget()
        {
            Swipes currentDirection = target.MoveDirection;

            if (target.IsMoved)
            {
                float newPositionX;
                float newPositionZ;
                
                switch (currentDirection)
                {
                    case Swipes.TopRight:
                        newPositionZ = _targetTransform.position.z - _differenceDistance.y;
                        transform.DOMoveZ(newPositionZ, 1f);
                        break;
                    
                    case Swipes.BottomRight:
                        newPositionZ = _targetTransform.position.x + _differenceDistance.x;
                        transform.DOMoveX(newPositionZ, 1f);
                        break;
                    
                    case Swipes.TopLeft:
                        newPositionX = _targetTransform.position.x + _differenceDistance.x;
                        transform.DOMoveX(newPositionX, 1f);
                        break;
                    
                    case Swipes.BottomLeft:
                        newPositionX = _targetTransform.position.z - _differenceDistance.y;
                        transform.DOMoveZ(newPositionX, 1f);
                        break;
                }
                
            }
        }
        

    }
}