using UnityEngine;
using UnityEngine.Events;

namespace Cubes
{
    public class CubeList : MonoBehaviour
    {
        public UnityEvent unLockHoleEvent;
        
        private int _currentCubeCount;
        private int _startCubeCount;


        private void Start()
        {
            _startCubeCount = transform.childCount;
        }


        public void AddCube()
        {
            _currentCubeCount++;

            if (_currentCubeCount >= _startCubeCount)
            {
                unLockHoleEvent.Invoke();
            }    
            
        }



    }
}