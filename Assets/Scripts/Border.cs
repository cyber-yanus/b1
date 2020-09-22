using UnityEngine;


namespace DefaultNamespace
{
    public class Border : MonoBehaviour
    {
        [SerializeField] private Rigidbody heroRigidbody;
        [SerializeField] private GroundCheck heroGroundCheck;

        private void OnTriggerEnter(Collider other)
        {
            var tag = other.transform.parent.parent.tag;
            if (tag.Equals("Player") && !heroGroundCheck.isEnterGround)
            {
                Debug.Log("hero enter border");
                heroRigidbody.isKinematic = false;
                heroRigidbody.useGravity = true;
            }
            
        }
    }
}