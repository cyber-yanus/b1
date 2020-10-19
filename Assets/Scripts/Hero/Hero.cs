using UnityEngine;



namespace DefaultNamespace
{
    public class Hero : MonoBehaviour
    {
        public Color color;
        
        private HeroCollisionCheck _heroCollisionCheck;
        private MeshRenderer _meshRenderer;
        private int _connectCheck;
        
 
        
        private void Awake()
        {
            _heroCollisionCheck = GetComponent<HeroCollisionCheck>();
            _meshRenderer = GetComponentInChildren<MeshRenderer>();
        }

        private void FixedUpdate()
        {
            bool isGrounded = _heroCollisionCheck.isEnterGround;
        }


        public void AddColor(Color color)
        {
            var material = _meshRenderer.material;
            material.color = color;
            
            this.color = color;
        }

        public int AddCubeCount => transform.childCount - 1;
    }
    
}