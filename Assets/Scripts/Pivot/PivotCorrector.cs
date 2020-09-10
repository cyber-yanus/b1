using UnityEngine;

namespace DefaultNamespace
{
    public class PivotCorrector : MonoBehaviour
    {
        private FigureSize _figureSize;
        private float step;
        
        private void Start()
        {
            _figureSize = GetComponentInParent<FigureSize>();
             step = transform.parent.transform.localScale.x / 2;
        }


        private void Update()
        {
            correctPivotPosition();
        }


        private void correctPivotPosition()
        {
            float pivotPositionX = (_figureSize.LeftWidthSide - 1) * step;
            float pivotPositionY = (_figureSize.HeightSide - 1) * step;
            float pivotPositionZ = (_figureSize.RightWidthSide - 1) * step;
            
            transform.localPosition = new Vector3(pivotPositionX, pivotPositionY, pivotPositionZ);
        }
    }
}