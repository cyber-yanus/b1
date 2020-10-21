using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace.Hole
{
    public class HoleLight : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer leftSpriteLight;
        [SerializeField] private SpriteRenderer rightSpriteRenderer;


        private IEnumerator Start()
        {
            yield return new WaitForSeconds(3f);

            MoveUp();
        }

        private void MoveUp()
        {
            transform.DOScaleY(0.2f, 1f);
        }

        public void RepaintLights()
        {
            leftSpriteLight.DOColor(Color.white, 2f);
            rightSpriteRenderer.DOColor(Color.white, 2f);

        }

    }
}