using UnityEngine;

namespace DefaultNamespace.Blades
{
    public class BladeTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("cube"))
            {
                Transform parentCube = other.transform.parent.parent;

                if (parentCube.GetComponent<FigureSize>())
                {
                    FigureSize figureSize = parentCube.GetComponent<FigureSize>();
                    figureSize.RemoveEllementFromArray(ConnectSide.Height);
                }
                
                other.gameObject.SetActive(false);    
            }
            
        }
        
        
    }
    
    
}