using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace.Ground
{
    public class CurrentRotate : MonoBehaviour
    {
        [SerializeField]private RotateDirection direction = RotateDirection.None;

        public RotateDirection Direction
        {
            get => direction;
            set => direction = value;
        }
    }
}