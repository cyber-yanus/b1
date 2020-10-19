using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class Obstacle : MonoBehaviour
    {
        public Color color;
        
        private void Start()
        {
            SelectColor();
        }

        private void SelectColor()
        {
            var meshRenderer = GetComponent<MeshRenderer>();
            var material = meshRenderer.material;

            color = material.color;
        }


    }
}