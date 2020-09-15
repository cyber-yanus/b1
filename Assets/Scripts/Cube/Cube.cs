using DefaultNamespace;
using DefaultNamespace.Touches;
using UnityEngine;

namespace Cubes
{
    public class Cube : MonoBehaviour
    {
        private CubeRays _cubeRays;
        
        
        private void Start()
        {
            _cubeRays = new CubeRays(transform);
        }

        
        public void Connects()
        {
            int connectCount = 0;
            Hero hero = default;
            ConnectSide connectSide = default;
            Vector3 rayDirection = Vector3.zero;
            
            
            foreach (var ray in _cubeRays.Rays)
            {
                if (Physics.Raycast(ray, out var hit, _cubeRays.RayDistance))
                {
                    if (hit.transform.tag.Equals("Player"))
                    {
                        Debug.Log("connect with player");

                        connectCount++;

                        hero = hit.transform.GetComponent<Hero>();
                        rayDirection = ray.direction;
                        connectSide = SelectSideType(rayDirection);
                        
                        if (connectSide == ConnectSide.Height)
                        {
                            hero.SetPositionForHeight();
                        }
                        
                        Transform parent = hit.transform.GetChild(0);
                        transform.parent = parent;
                        
                        transform.GetComponent<Cube>().enabled = false;
                    }
                }
            }

            
            if (connectCount == 1)
            {
                if (hero != null) 
                    hero.ConnectActions(connectSide, rayDirection);
            }
            
        }
        
        private ConnectSide SelectSideType(Vector3 direction)
        {
            if (direction == Vector3.up || direction == Vector3.down)
                return ConnectSide.Height;
            
            if (direction == Vector3.left || direction == Vector3.right)
                return ConnectSide.LeftWidth;
            
            if (direction == Vector3.forward || direction == Vector3.back)
                return ConnectSide.RightWidth;

            return ConnectSide.Height;
        }
     
    }
}