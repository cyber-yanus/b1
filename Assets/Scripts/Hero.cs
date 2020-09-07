using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class Hero : MonoBehaviour
    {
        [SerializeField]private ConnectCheck connectCheck;
        
        private GroundCheck _groundCheck;
        private FigureSize _figureSize;

        private int _permission;
        
        
        private void Awake()
        {
            _groundCheck = GetComponent<GroundCheck>();
            _figureSize = GetComponent<FigureSize>();
        }


       

        private void Update()
        {
            bool isGrounded = _groundCheck.isGrounded;

            if (!isGrounded)
            {
                _permission = 0;
            }
        }


        private void FixedPosition(Transform trans)
        {
            DOTween.KillAll();
            
            float newPositionX = trans.position.x;
            float newPositionY = transform.position.y;
            float newPositionZ = trans.position.z;
            
            transform.position = new Vector3(newPositionX, newPositionY, newPositionZ);

            trans.parent = transform.parent;
        }

        public void ConnectCube(Transform cubeTransform, SideType sideConnect)
        {
            
            bool isGrounded = _groundCheck.isGrounded;

            if (sideConnect == SideType.LeftWidth || sideConnect == SideType.RightWidth)
            {
                //в дальнейшем заменить permission на другое 
                if (isGrounded && _permission == 0)
                {
                    _permission++;
                    cubeTransform.parent = transform;
                    cubeTransform.GetComponent<ConnectCheck>().enabled = false;

                    _figureSize.AddEllementToArray(sideConnect);
                }
            }
            else if (sideConnect == SideType.Height)
            {
                cubeTransform.parent = transform;
                cubeTransform.GetComponent<ConnectCheck>().enabled = false;

                _figureSize.AddEllementToArray(sideConnect);
            }

        }


    }
    
}