using UnityEngine;

namespace DefaultNamespace.Hole
{
    public class HoleTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            string tag = other.tag;
            if (tag.Equals("cube"))
            {
                Transform parent = other.transform.parent.parent;
                Rigidbody rb = parent.GetComponent<Rigidbody>();
                rb.useGravity = true;
                other.gameObject.layer = 8;

//                Transform parent = other.transform.parent.parent;
//
//                Rigidbody rb = parent.GetComponent<Rigidbody>();
//                rb.useGravity = true;
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