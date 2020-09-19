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
        private MoveHero _moveHero;
        
        private int _connectCheck;
        

        
        
        private void Awake()
        {
            _pivotCorrector = GetComponent<PivotCorrector>();
            _groundCheck = GetComponent<GroundCheck>();
            _figureSize = GetComponent<FigureSize>();
            _moveHero = GetComponent<MoveHero>();
        }
       

        private void Update()
        {
            bool isGrounded = _groundCheck.isEnterGround;
           
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

        public void ConnectActions(Transform cube, ConnectSide connectSide, Vector3 connectDirection)
        {
           
            Vector3 cubePos = cube.position;
            cube.position = new Vector3(Mathf.Round(cubePos.x), Mathf.Round(cubePos.y), Mathf.Round(cubePos.z));
            //cube.rotation = Quaternion.Euler(0, 0, 0);
            
            
            _figureSize.AddEllementToArray(connectSide);
            _pivotCorrector.CorrectPivotPosition(connectDirection);            
        }

        public void SetPositionForHeight()
        {
            float x = _moveHero.PositionXForJump1;
            float y = _moveHero.PositionYForJump1 + 1f;
            float z = _moveHero.PositionZForJump1;

            transform.position = new Vector3(x, y, z);
        }

        public int GetSideLength(ConnectSide side)
        {
            if (side == ConnectSide.Height)
            {
                return _figureSize.HeightSide;
            }
            
            if(side == ConnectSide.LeftWidth)
            {
                return _figureSize.LeftWidthSide;
            }

            if (side == ConnectSide.RightWidth)
            {
                return _figureSize.RightWidthSide;
            }

            return 0;
        }

    }
    
}