using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class HeroCollisionCheck : MonoBehaviour
    {
        private MoveHero _moveHero;
        private Hero _hero;
        
        public bool isEnterGround;
        

        private void Start()
        {
            _moveHero = GetComponent<MoveHero>();
            _hero = GetComponent<Hero>();
        }
        
        private void OnCollisionEnter(Collision other)
        {
            var tag = other.transform.tag;

            switch (tag)
            {
                case "obstacle":
                    var obstacle = other.transform.GetComponent<Obstacle>();

                    if (obstacle.color != Color.white)
                    {
                        _hero.AddColor(obstacle.color);    
                    }
                    
                    _moveHero.isMove = false;
                    break;
                
                case "cube":
                    PunchAnimation();
                    _moveHero.isMove = false;
                    break;
            }
            
        }

        private void PunchAnimation()
        {
            Vector3 punch = Vector3.one / 2;
            transform.DOPunchScale(punch, 0.25f, 1);
        }


    }
    
    
}