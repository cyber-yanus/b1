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
        
        public void Smena(MoveDirection moveDirection)
        {
            int saveFigureCount = widthCubeCount;
            
            if (moveDirection == MoveDirection.Left)
            {
                leftWidthSide = widthCubeCount = heightSide;
            }
            else if (moveDirection == MoveDirection.Right)
            {
                rightWidthSide = widthCubeCount = heightSide;
            }
            
            heightSide = heightCubeCount = saveFigureCount;
        }


        public int WidthCubeCount => widthCubeCount;
//        public int HeightSide => heightSide;
        public int HeightCubeCount => heightCubeCount;


        public int HeightSide => heightSide;
        public int LeftWidthSide => leftWidthSide;
        public int RightWidthSide => rightWidthSide;

//        public int GetMaxSize()
//        {
//            return Mathf.Max(heightCubeCount, widthCubeCount);
//        }

    }
    
    
    public enum SideType
    {
        Height,
        LeftWidth,
        RightWidth
    }
    
}