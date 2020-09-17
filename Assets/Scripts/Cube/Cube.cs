using System.Linq;
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
            int size = 0;
            int maxSize;
            //string hitName = default;
            Hero hero = default;
            RaycastHit[] hits;
            ConnectSide connectSide = default;
            Vector3 rayDirection = Vector3.zero;
            
            
            foreach (var ray in _cubeRays.DirectRays)
            {
                if (Physics.Raycast(ray, out var hit, _cubeRays.RayDistance))
                {
                    if (hit.transform.tag.Equals("Player"))
                    {
                        Debug.Log("connect with player");

                        connectCount++;
                        
                        hits = Physics.RaycastAll(ray);
                        size = hits.Length + 1;
                        foreach (var hitus in hits)
                        {
                            var name = hitus.collider.name;
                            if (name.Equals("Cube"))
                            {
                                size -= 2;
                            }    
                        }
                        Debug.Log("Size = " + size);



                        hero = hit.transform.GetComponent<Hero>();
                        rayDirection = ray.direction;
                        connectSide = SelectSideType(rayDirection);
                        maxSize = hero.GetSideLength(connectSide);

                        if (size > maxSize)
                        {
                            if (connectSide == ConnectSide.Height)
                                hero.SetPositionForHeight();
                    
                            hero.ConnectActions(transform, connectSide, rayDirection);
                        }
                        
                        if (connectCount == 1)
                        {
                            Transform parent = hit.transform.GetChild(0);
                            transform.parent = parent;
                        }
                        
                        transform.GetComponent<Cube>().enabled = false;
                        transform.GetChild(0).gameObject.SetActive(false);
                    }
                }
            }

           
        }

        private void Update()
        {
            _cubeRays.DrawRays();
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