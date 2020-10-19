using DefaultNamespace;
using DG.Tweening;
using UnityEngine;

namespace Cubes
{
    public class Cube : MonoBehaviour
    {   
        
        private void OnCollisionStay(Collision other)
        {
            var tag = other.transform.tag;

            if (tag.Equals("Player"))
            {       
                transform.parent = other.transform;
                
                int addCubeCount = GetComponentInParent<Hero>().AddCubeCount - 1;

                Vector3 heroPosition = other.transform.position;
                float positionX = heroPosition.x;
                float positionY = heroPosition.y + addCubeCount;
                float positionZ = heroPosition.z;
                
                
                Vector3 endPosition = new Vector3(positionX, positionY, positionZ);
                
                
                Jump(endPosition);
            }
        }

        private void Jump(Vector3 endPosition)
        {
            transform.DOJump(endPosition, 1, 0, 0.25f).SetEase(Ease.Linear);
        }
    }
}