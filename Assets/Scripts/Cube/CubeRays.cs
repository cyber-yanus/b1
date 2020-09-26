using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Touches
{
    public class CubeRays
    {
        private Transform _cube;
        private List<Ray> _directRays;
        
        private float _rayDistance;
        

        public CubeRays(Transform cube)
        {
            _cube = cube;
            _rayDistance = 0.01f;
            
            
            CalculateRayDistance();
            InitializationRays();
        }

        public void InitializationRays()
        {
            Vector3 origin = _cube.position;
            _directRays = new List<Ray>
            {
                new Ray(origin, Vector3.left),
                new Ray(origin, Vector3.right),
                new Ray(origin, Vector3.back),
                new Ray(origin, Vector3.forward),               
            };
        }

        private void CalculateRayDistance()
        {
            _rayDistance += _cube.localScale.x / 2f;
        }

        public void DrawRays()
        {
            foreach (var ray in _directRays)
            {
                Debug.DrawRay(ray.origin, ray.direction * _rayDistance, Color.black);                        
            }
        }

        
        public List<Ray> DirectRays => _directRays;
        public float RayDistance => _rayDistance;
    }
}