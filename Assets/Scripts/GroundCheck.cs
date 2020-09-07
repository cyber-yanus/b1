using UnityEngine;

namespace DefaultNamespace
{
    public class GroundCheck : MonoBehaviour
    {
        public bool isGrounded;
        
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.tag.Equals("ground"))
            {
                Debug.Log("enter ground");
                isGrounded = true;
            }
            
        }

        
        
        private void OnCollisionExit(Collision other)
        {
            if (other.transform.tag.Equals("ground"))
            {
                Debug.Log("exit ground");
                isGrounded = false;
            }
            
        }
        
        
    }
    
    
}