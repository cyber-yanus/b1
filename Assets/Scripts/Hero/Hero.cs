using System;
using Cubes;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private Transform membrane;
        
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

        public void ConnectActions(ConnectSide connectSide, Vector3 connectDirection)
        {
            _figureSize.AddEllementToArray(connectSide);
            _pivotCorrector.CorrectPivotPosition(connectDirection);            
        }

        public void SetPositionForHeight()
        {
            float x = _moveHero.PositionXForJump1;
            float y = _moveHero.PositionYForJump1 + 1f;
            float z = _moveHero.PositionZForJump1;

            transform.localPosition = new Vector3(x, y, z);
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

        public void MembranePositionUpdate()
        {
            Vector3 membrPosition = membrane.localPosition;
            float x = membrPosition.x;
            float y = membrPosition.y;
            float z = membrPosition.z;
            
            if (membrPosition.x < 0)
            {
                x = Mathf.Abs(x);
                x = x % 0.5f < 0.3f ? x - (x % 0.5f) : x - (x % 0.5f) + 0.5f;
                x *= -1;
            }
            else
            {
                x = x % 0.5f < 0.3f ? x - (x % 0.5f) : x - (x % 0.5f) + 0.5f;
            }

            if (membrPosition.y < 0)
            {
                y = Mathf.Abs(y);
                y = y % 0.5f < 0.3f ? y - (y % 0.5f) : y - (y % 0.5f) + 0.5f;
                y *= -1;
            }
            else
            {
                y = y % 0.5f < 0.3f ? y - (y % 0.5f) : y - (y % 0.5f) + 0.5f;
            }

            if (membrPosition.z < 0)
            {
                z = Mathf.Abs(z);
                z = z % 0.5f < 0.3f ? z - (z % 0.5f) : z - (z % 0.5f) + 0.5f;
                z *= -1;
            }
            else
            {
                z = z % 0.5f < 0.3f ? z - (z % 0.5f) : z - (z % 0.5f) + 0.5f;
            }
                       
            membrane.localPosition = new Vector3(x,y,z);
            
            Debug.Log("mem = " + membrane.localPosition);
        }
    }
    
}