using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class ObstacleMove : MonoBehaviour
    {   
        [SerializeField] private Vector3 firstEndPosition;
        [SerializeField] private Vector3 secondEndPosition;

        [SerializeField] private float moveDuration;


        private void Start()
        {
            FirstMove();
        }

        private void FirstMove()
        {
            transform.DOLocalMove(firstEndPosition, moveDuration).OnComplete(SecondMove);
        }

        private void SecondMove()
        {
            transform.DOLocalMove(secondEndPosition, moveDuration).OnComplete(FirstMove);
        }
    }
}