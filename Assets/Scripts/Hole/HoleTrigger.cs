using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace.Hole
{
    public class HoleTrigger : MonoBehaviour
    {
        [SerializeField] private HoleLight holeLight;
        public UnityEvent loadNextLevelEvent;
        
        private BoxCollider _boxCollider;
        
        
        private void Start()
        {
            _boxCollider = GetComponent<BoxCollider>();
        }


        private void OnTriggerStay(Collider other)
        {
            string tag = other.tag;
            if (tag.Equals("Player"))
            {
                other.gameObject.layer = 8;
                StartCoroutine(EndLevel());
            }
        }


        private void OnTriggerExit(Collider other)
        {
            string tag = other.tag;
            if (tag.Equals("Player"))
            {
                other.gameObject.layer = 0;
            }
        }

        public void UnLockHole()
        {
            _boxCollider.enabled = true;

            holeLight.RepaintLights();
        }

        private IEnumerator EndLevel()
        {
            yield return new WaitForSeconds(3f);
            loadNextLevelEvent.Invoke();
        }
        

    }
}