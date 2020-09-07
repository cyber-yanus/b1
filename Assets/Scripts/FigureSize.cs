using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;


namespace DefaultNamespace
{
    public class FigureSize : MonoBehaviour
    {
        
        [SerializeField]private int heightSide = 1;
        [SerializeField]private int rightWidthSide = 1;
        [SerializeField]private int leftWidthSide = 1;
        
        private int widthCubeCount;
        private int heightCubeCount;

        


        public void InitCubeCount(MoveDirection moveDirection)
        {
            heightCubeCount = heightSide; 
            
            if (moveDirection == MoveDirection.Left)
            {
                widthCubeCount = leftWidthSide;
            }
            else if (moveDirection == MoveDirection.Right)
            {
                widthCubeCount = rightWidthSide;
            }
        }

        public void AddEllementToArray(SideType side)
        {
            switch (side)
            {
                case SideType.Height:
                    heightSide++;
                    break;
                
                case SideType.LeftWidth:
                    leftWidthSide++;
                    break;
                
                case SideType.RightWidth:
                    rightWidthSide++;
                    break;
            }
            
        }
        
        public void Smena()
        {
            int saveFigureCount = widthCubeCount;
            
            widthCubeCount = heightCubeCount;
            heightCubeCount = saveFigureCount;
        }


        public int WidthCubeCount => widthCubeCount;
        public int HeightSide => heightSide;
    }
    
    
    public enum SideType
    {
        Height,
        LeftWidth,
        RightWidth
    }
    
}