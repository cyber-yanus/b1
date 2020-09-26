using System.Collections.Generic;
using Cubes;
using UnityEngine;

namespace DefaultNamespace
{
    public class CubesCheck : MonoBehaviour
    {
        [SerializeField] private Hero _hero;
        private List<Cube> _cubes;



        private void Start()
        {
            _cubes = new List<Cube>();
        }
        
        private void Update()
        {
            CheckFreeCube();
        }

        private void CheckFreeCube()
        {
            
            int freeCubeCount = transform.childCount;

            if (freeCubeCount == 0)
            {
                Debug.Log("Что-то собрал, хуй пойми что:)");
            }
        }

        
        
        
        public void CheckConnects()
        {   
            InitializationCubes();
            
            foreach (var cube in _cubes)
            {
                cube.Connects();
            }
            
            _hero.MembranePositionUpdate();
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