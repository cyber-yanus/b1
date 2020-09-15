using UnityEngine;


namespace DefaultNamespace
{
    public class PivotCorrector : MonoBehaviour
    {
        private Transform _children;
        
        private float _step;
        
        private void Start()
        {
            _children = transform.GetChild(0);
            
            _step = transform.localScale.x / 2;
        }


        public void CorrectPivotPosition(Vector3 connectDirection)
        {
//            if (connectDirection == Vector3.up)
//            {
//                connectDirection = Vector3.down;
//            }
//            else if (connectDirection == Vector3.down)
//            {
//                connectDirection = Vector3.up;
//            }


            Vector3 pivotPosition = connectDirection * _step;

            _children.position += pivotPosition;
            transform.position -= pivotPosition;
        }
    }
}