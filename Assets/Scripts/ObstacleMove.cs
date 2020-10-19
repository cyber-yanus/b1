using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class ObstacleMove : MonoBehaviour
    {
        [SerializeField] private ObstacleStartDirection direction;

        private float _defaultPosition;


        private void Start()
        {
            InitDefaultPosition();
            Move();
        }

        private void InitDefaultPosition()
        {
            if (direction == ObstacleStartDirection.Left || direction == ObstacleStartDirection.Right)
            {
                _defaultPosition = transform.position.x;
            }
            else
            {
                _defaultPosition = transform.position.z;
            }
            
            
        }

        private void Move()
        {
            
            
        }
    }


    public enum ObstacleStartDirection
    {
        Left,
        Right,
        Forward,
        Back
    }
}