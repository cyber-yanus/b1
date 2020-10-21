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
            
            //yield return new WaitForSeconds(5f);
            
            DefaultState();
        }

        public IEnumerator ActivateDestroyState()
        {
            float randomTime = Random.Range(5f, 10f);
            activeDestroyState = true;
            
            yield return new WaitForSeconds(randomTime);
            PreparationState();
        }
        
        
        private void DefaultState()
        {
            _destroyStateTween.Kill();

            Vector3 endPosition = transform.localPosition;

            _defaultStateTween = transform.DOLocalJump(endPosition, 1, 0, jumpDuration)
                .SetLoops(-1);
        }

        private void PreparationState()
        {
            _defaultStateTween.Kill();
            
            Vector3 endPosition = transform.up * 3;
            
            _preparationStateTween = transform.DOMoveY(endPosition.y, 1f)
                .SetEase(Ease.OutQuart);
        }

        private void PunchBlade()
        {
            Vector3 endPosition = new Vector3(0.005f, 0.005f, 0.005f);
            
            _preparationStateTween = transform.DOPunchScale(endPosition, 1f)
                .SetLoops(2).OnComplete(AfterDestroyState);
        }

        private void AfterDestroyState()
        {
            transform.DOMoveY(_startPosition.y, 1f).OnComplete(DefaultState);
            activeDestroyState = false;
        }




    }





}