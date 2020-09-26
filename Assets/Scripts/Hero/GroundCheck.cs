using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class GroundCheck : MonoBehaviour
    {
        private MoveHero _moveHero;
        
        public bool isEnterGround;
        

        private void Start()
        {
            _moveHero = GetComponent<MoveHero>();
        }

        private void OnTriggerEnter(Collider other)
        {
            string tag = other.transform.tag;

            if (tag.Equals("ground"))
            {
                Debug.Log("enter ground");
                isEnterGround = true;
            }else if (tag.Equals("up cube"))
            {
                Debug.Log("up cube enter");
                isEnterGround = true;   
                _moveHero.removeJumpTween();
            }
        }



        private void OnTriggerExit(Collider other)
        {
            string tag = other.transform.tag;

            if (tag.Equals("ground"))
            {
                Debug.Log("exit ground");
                isEnterGround = false;
            }
            else if (tag.Equals("up cube"))
            {
                Debug.Log("up cube exit");
                isEnterGround = false;
            }           
        }
        
    }
    
    
}