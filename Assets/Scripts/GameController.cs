using System.Collections;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;

namespace Gradient
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private float endPositionY;
        [SerializeField] private Hero hero;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);
            transform.DOMoveY(endPositionY, 3f).OnComplete(() => {hero.gameObject.SetActive(true);});
        }

    }
}