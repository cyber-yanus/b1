using DG.Tweening;
using UnityEngine;

namespace Gradient
{
    public class Level : MonoBehaviour
    {
        


        public void Appearance()
        {
            transform.parent = transform.parent.parent;
        }

        public void Disappearance()
        {
            transform.DOLocalMoveY(100f, 3f);
        }
    }
}