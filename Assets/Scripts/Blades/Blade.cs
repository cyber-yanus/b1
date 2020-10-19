using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;


namespace DefaultNamespace.Blades
{
    public class Blade : MonoBehaviour
    {
        [SerializeField] private bool activeDestroyState;
        [SerializeField] private float jumpDuration;
        
        private Vector3 _startPosition;
        
        private Tween _defaultStateTween;
        private Tween _preparationStateTween;
        private Tween _destroyStateTween;
        
        private void Start()
        {
            _startPosition = transform.position;
            
            DefaultState();
        }

        
        private void Update()
        {
            if (!activeDestroyState)
            {
                StartCoroutine(ActivateDestroyState());
            }
        }

        
        public IEnumerator ActivateDestroyState()
        {
            float randomTime = Random.Range(5f, 10f);
            activeDestroyState = true;
            
            yield return new WaitForSeconds(randomTime);
            PreparationState();
//            yield return new WaitForSeconds(3f);
//            DestroyState();
        }
        
        
        private void DefaultState()
        {
            _destroyStateTween.Kill();

            Vector3 endPosition = transform.position;

            _defaultStateTween = transform.DOJump(endPosition, 1, 0, jumpDuration)
                .SetLoops(-1);
        }

        private void PreparationState()
        {
            _defaultStateTween.Kill();
            
            Vector3 endPosition = transform.up * 3;
            
            _preparationStateTween = transform.DOMoveY(endPosition.y, 1f)
                .SetEase(Ease.OutQuart)
                .OnComplete(PunchBlade);
        }

        private void PunchBlade()
        {
            Vector3 endPosition = new Vector3(0.005f, 0.005f, 0.005f);
            
            _preparationStateTween = transform.DOPunchScale(endPosition, 1f)
                .SetLoops(2).OnComplete(AfterDestroyState);
        }

//        private void DestroyState()
//        {
//            _preparationStateTween.Kill();
//
//            Vector3 bladeScale = transform.localScale * -1;
//
//            _destroyStateTween = transform.DOScale(bladeScale, 1f)
//                .OnComplete(AfterDestroyState);
//        }

        private void AfterDestroyState()
        {
            transform.DOMoveY(_startPosition.y, 1f).OnComplete(DefaultState);
            activeDestroyState = false;
        }




    }





}