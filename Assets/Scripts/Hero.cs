using Cubes;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class Hero : MonoBehaviour
    {
        public UnityEvent connectCheckEvent;
        
        
        private PivotCorrector _pivotCorrector;
        private GroundCheck _groundCheck;
        private FigureSize _figureSize;
        
        private int _connectCheck;
        

        
        
        private void Awake()
        {
            _pivotCorrector = GetComponent<PivotCorrector>();
            _groundCheck = GetComponent<GroundCheck>();
            _figureSize = GetComponent<FigureSize>();
        }
       

        private void Update()
        {
            bool isGrounded = _groundCheck.isGrounded;

            //connectCheckEvent.Invoke();
            
            
            if (!isGrounded)
            {
                _connectCheck = 0;
            }
            else
            {
                if (_connectCheck == 0)
                {
                    connectCheckEvent.Invoke();
                    _connectCheck++;
                }
            }
            
        }


        public void ConnectActions(ConnectSide connectSideConnect, Vector3 connectDirection)
        {
            
            _figureSize.AddEllementToArray(connectSideConnect);
            _pivotCorrector.CorrectPivotPosition(connectDirection);            
        }


    }
    
}