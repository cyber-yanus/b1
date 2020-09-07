using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class BojoRay
    {
        public static List<BojoRay> BojoRays = new List<BojoRay>();
        
        private float _rayDistance;
        private SideType _sideType;
        private Ray _ray;

        
        public BojoRay(Vector3 origin, Vector3 direction, float rayDistance)
        {
            _rayDistance = rayDistance;
            _ray = new Ray(origin, direction);
    
            BojoRays.Add(this);

            SelectSideType(direction);
        }

        private void SelectSideType(Vector3 direction)
        {
            if (direction == Vector3.up || direction == Vector3.down)
                _sideType = SideType.Height;
            else if (direction == Vector3.left || direction == Vector3.right)
                _sideType = SideType.LeftWidth;
            else if (direction == Vector3.forward || direction == Vector3.back)
                _sideType = SideType.RightWidth;
        }

        public void DrawRay()
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _rayDistance, Color.black);
        }

        public static void UpdateStartPosition(Vector3 newPosition)
        {
            foreach (var bojoRay in BojoRays)
            {
                bojoRay._ray.origin = newPosition;
            }
        }
        
        
        public Ray Ray => _ray;
        public SideType SideType => _sideType;
    }
}