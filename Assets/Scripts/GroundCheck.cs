using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class GroundCheck : MonoBehaviour
    {
        public bool isGrounded;
        public bool isEnterCube;
        
        
        private void OnCollisionEnter(Collision other)
        {
            string tag = other.transform.tag;

            switch (tag)
            {
                case "ground":
                    Debug.Log("enter ground");
                    isGrounded = true;
                     break;
                
//                case "cube":
//                    Debug.Log("enter cube");
//                    isEnterCube = true;
//                    break;
            }
        }

        
        
        private void OnCollisionExit(Collision other)
        {
            string tag = other.transform.tag;
            
            switch (tag)
            {
                case "ground":
                    Debug.Log("exit ground");
                    isGrounded = false;
                    break;    
                
//                case "cube":
//                    Debug.Log("exit cube");
//                    isEnterCube = false;
//                    break;
            }
        }
        
        
    }
    
    
}