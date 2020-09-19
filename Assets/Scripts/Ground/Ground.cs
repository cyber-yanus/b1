using UnityEngine;

namespace DefaultNamespace.Ground
{
    public class Ground : MonoBehaviour
    {
        [SerializeField] private CurrentRotate currentRotate;


        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            switch (currentRotate.Direction)
            {
                case RotateDirection.Left:
                    transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
                    break;
                    
                case RotateDirection.Forward:
                    transform.rotation = Quaternion.AngleAxis(90, Vector3.right);
                    break;
            }
            
        }

    }
}