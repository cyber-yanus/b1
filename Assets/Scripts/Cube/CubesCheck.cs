using System.Collections.Generic;
using Cubes;
using UnityEngine;

namespace DefaultNamespace
{
    public class CubesCheck : MonoBehaviour
    {
        private List<Cube> _cubes;
        
        
        
        private void Start()
        {
            _cubes = new List<Cube>();
        }

  
        public void CheckConnects()
        {
            InitializationCubes();
            
            foreach (var cube in _cubes)
            {
                cube.Connects();
            }
            
        }

        private void InitializationCubes()
        {
            //посмотреть тип без повторений 
            _cubes.Clear();
            
            int cubesCount = transform.childCount;
            for (int i = 0; i < cubesCount; i++)
            {
                Cube cube = transform.GetChild(i).GetComponent<Cube>();
                if (cube.enabled)
                {
                    _cubes.Add(cube);    
                }
                                                                
            }
        }

        
    }
}