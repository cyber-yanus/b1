using UnityEngine;
using UnityEngine.Events;

namespace Gradient
{
    public class EndLevelTrigger : MonoBehaviour
    {
        public UnityEvent nextLevelEvent;
        
        private void OnTriggerEnter(Collider other)
        {
            var tag = other.tag;
            if (tag.Equals("Player"))
            {
                nextLevelEvent.Invoke();    
            }
        }
    }
}