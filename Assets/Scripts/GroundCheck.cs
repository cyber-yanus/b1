using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class GroundCheck : MonoBehaviour
    {
        public bool isEnterGround;
        private Hero _hero;


        private void Start()
        {
            _hero = GetComponent<Hero>();
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
                DOTween.KillAll();
                //_hero.SetPositionForHeight();
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