using DefaultNamespace;
using DG.Tweening;
using Lean.Touch;
using UnityEngine;

namespace Cubes
{
    public class Cube : MonoBehaviour
    {
        public Color color;

        private MeshRenderer _meshRenderer;
        private Sequence _sequence;
        
        private void Start()
        {
            _meshRenderer = transform.GetComponent<MeshRenderer>();
            SelectColor();
        }

        private void SelectColor()
        {
            var meshRenderer = GetComponent<MeshRenderer>();
            var material = meshRenderer.material;

            color = material.color;
        }

        private void OnCollisionStay(Collision other)
        {
            var tag = other.transform.tag;

            if (tag.Equals("Player"))
            {
                var hero = other.transform.GetComponent<Hero>();

                if (hero.color == color)
                {
                    transform.GetComponent<BoxCollider>().enabled = false;
                    
                    Vector3 endPosition = transform.localPosition;
                    Merge(hero.transform, endPosition);
                }
            }
        }

        private void Merge(Transform target, Vector3 endPosition)
        {
            _sequence.Join(transform.DOJump(endPosition, 3, 0, .5f).OnComplete(DisableCube));
            _sequence.Join(transform.DOScale(transform.localScale / 2f, 1f));
            
            target.DOMove(endPosition, 0.25f).SetEase(Ease.Linear);
        }

        private void DisableCube()
        {
            _meshRenderer.enabled = false;
        }

        private void Jump(Vector3 endPosition)
        {
            transform.DOJump(endPosition, 1, 0, 0.25f).SetEase(Ease.Linear);
        }
    }
}