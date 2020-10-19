using System.Collections;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;

namespace Gradient
{
    public class Levels : MonoBehaviour
    {
        [SerializeField] private Hero hero;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);
            transform.DOMoveY(0, 3f).OnComplete(() => {hero.gameObject.SetActive(true);});
        }

    }
}