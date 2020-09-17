using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Touches
{
    public class CubeRays
    {
        private Transform _cube;
        private List<Ray> _directRays;
        private List<Ray> _diagonalRays;
        
        private float _rayDistance;
        private float _diagonalRayDistance;
        
        

        public CubeRays(Transform cube)
        {
            _cube = cube;
            _rayDistance = 0.001f;
            _diagonalRayDistance = 0.001f;
            
            CalculateRayDistance();
            InitializationRays();
        }

        private void InitializationRays()
        {
            Vector3 origin = _cube.position;
            _directRays = new List<Ray>
            {
                new Ray(origin, Vector3.up),
                new Ray(origin, Vector3.down),
                new Ray(origin, Vector3.left),
                new Ray(origin, Vector3.right),
                new Ray(origin, Vector3.back),
                new Ray(origin, Vector3.forward),               
            };
            
            _diagonalRays = new List<Ray>
            {
                new Ray(origin, new Vector3(25, 0, 25)),
                new Ray(origin, new Vector3(-25, 0, -25)),
                new Ray(origin, new Vector3(25, 0, -25)),
                new Ray(origin, new Vector3(-25, 0, 25)),
            };
        }

        private void CalculateRayDistance()
        {
            _rayDistance += _cube.localScale.x / 2f;
            _diagonalRayDistance += _cube.localScale.x * Mathf.Sqrt(2) / 2;
        }

        public void DrawRays()
        {
            foreach (var ray in _directRays)
            {
                Debug.DrawRay(ray.origin, ray.direction * _rayDistance, Color.black);                        
            }

            foreach (var ray in _diagonalRays)
            {
                Debug.DrawRay(ray.origin, ray.direction * _diagonalRayDistance, Color.black);
            }
        }

        
        public List<Ray> DirectRays => _directRays;
        public List<Ray> DiagonalRays => _diagonalRays;

        public float RayDistance => _rayDistance;
        public float DiagonalRayDistance => _diagonalRayDistance;
    }
}