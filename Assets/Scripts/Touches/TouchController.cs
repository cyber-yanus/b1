using UnityEngine;

namespace DefaultNamespace.Touches
{
    public class TouchController : MonoBehaviour
    {
        //Subscribe to delegates here
        void OnEnable()
        {
            //Subscribing to events
            SwipeEvents.OnSwipeUp += OnSwipeUp;
            SwipeEvents.OnSwipeDown += OnSwipeDown;
            SwipeEvents.OnSwipeLeft += OnSwipeLeft;
            SwipeEvents.OnSwipeRight += OnSwipeRight;
            
            SwipeManager.OnSingleTapLeft += OnSingleTapLeft;
            SwipeManager.OnSingleTapRight += OnSingleTapRight;
            SwipeManager.OnDoubleTap += OnDoubleTap;
        }

        //Unubscribe to delegates here
        void OnDisable()
        {
            //! Always unsubscribe to events if you have subscribed to them
            //Unsubscribing to events
            SwipeEvents.OnSwipeUp -= OnSwipeUp;
            SwipeEvents.OnSwipeDown -= OnSwipeDown;
            SwipeEvents.OnSwipeLeft -= OnSwipeLeft;
            SwipeEvents.OnSwipeRight -= OnSwipeRight;
            
            SwipeManager.OnSingleTapLeft -= OnSingleTapLeft;
            SwipeManager.OnSingleTapLeft -= OnSingleTapRight;
            SwipeManager.OnDoubleTap -= OnDoubleTap;
        }
     
        
        private void OnSwipeUp()
        {
            Debug.Log("Up");
        }

        private void OnSwipeDown()
        {
            Debug.Log("Down");
        }

        private void OnSwipeLeft()
        {
            Debug.Log("Left");
        }

        private void OnSwipeRight()
        {
            Debug.Log("Right");
        }

        //Tap Callbacks
        private void OnSingleTapLeft()
        {
            Debug.Log("Tap left");
        }
        
        private void OnSingleTapRight()
        {
            Debug.Log("Tap right");
        }

        private void OnDoubleTap()
        {
            Debug.Log("Double Tap");
        }
    }
}