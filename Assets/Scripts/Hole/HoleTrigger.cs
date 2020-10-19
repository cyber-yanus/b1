using UnityEngine;

namespace DefaultNamespace.Hole
{
    public class HoleTrigger : MonoBehaviour
    {
        private void OnTriggerStay(Collider other)
        {
            string tag = other.tag;
            if (tag.Equals("cube"))
            {
                other.gameObject.layer = 8;
            }
        }


        private void OnTriggerExit(Collider other)
        {
            string tag = other.tag;
            if (tag.Equals("cube"))
            {
                other.gameObject.layer = 0;
            }
        }
    }
}