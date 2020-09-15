using Cubes;
using DG.Tweening;
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
        private bool _isGrounded;
        

        
        
        private void Awake()
        {
            _pivotCorrector = GetComponent<PivotCorrector>();
            _groundCheck = GetComponent<GroundCheck>();
            _figureSize = GetComponent<FigureSize>();
        }
       

        private void Update()
        {
            _isGrounded = _groundCheck.isEnterGround;
           
            if (!_isGrounded)
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


        public void ConnectActions(ConnectSide connectSide, Vector3 connectDirection)
        {
            _figureSize.AddEllementToArray(connectSide);
            _pivotCorrector.CorrectPivotPosition(connectDirection);            
        }


    }
    
}