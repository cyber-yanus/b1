using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class GroundCheck : MonoBehaviour
    {
        public bool isEnterGround;
        
        
        
        private void OnCollisionEnter(Collision other)
        {
            string tag = other.transform.tag;

            if (tag.Equals("ground"))
            {
                Debug.Log("enter ground");
                isEnterGround = true;
            }

            if (tag.Equals("up cube"))
            {
                Debug.Log("up cube enter");
                DOTween.KillAll();
            }
        }

        
        
        private void OnCollisionExit(Collision other)
        {
            string tag = other.transform.tag;

            if (tag.Equals("ground"))
            {
                Debug.Log("exit ground");
                isEnterGround = false;
            }
        }
        
        
    }
    
    
}