using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class HeroCollisionCheck : MonoBehaviour
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

            switch (tag)
            {
                case "obstacle":
                    _moveHero.isMove = false;
                    break;
                
                case "cube":
                    _moveHero.isMove = false;
                    break;
            }
            
        }

        private void OnCollisionExit(Collision other)
        {
            var tag = other.transform.tag;
        }
    }
    
    
}