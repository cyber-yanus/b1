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
        
        private void OnCollisionEnter(Collision other)
        {
            var tag = other.transform.tag;

            if (tag.Equals("ground"))
            {
                Debug.Log("enter ground");
                isEnterGround = true;
            }
            
        }

        private void OnCollisionExit(Collision other)
        {
            var tag = other.transform.tag;

            if (tag.Equals("ground"))
            {
                Debug.Log("exit ground");
                isEnterGround = false;
            }
            
        }
        
    }
    
    
}