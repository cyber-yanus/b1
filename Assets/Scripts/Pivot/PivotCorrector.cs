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
            Vector3 pivotPosition = connectDirection * _step;

            _children.position += pivotPosition;
            transform.position -= pivotPosition;
        }
    }
}