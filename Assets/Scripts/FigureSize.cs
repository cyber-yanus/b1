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
        
        private int widthCubeCount = 1;
        private int heightCubeCount = 1;

        

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

        public void AddEllementToArray(ConnectSide connectSide)
        {
            switch (connectSide)
            {
                case ConnectSide.Height:
                    heightSide++;
                    break;
                
                case ConnectSide.LeftWidth:
                    leftWidthSide++;
                    break;
                
                case ConnectSide.RightWidth:
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
        public int HeightCubeCount => heightCubeCount;
    }
    
    
    public enum ConnectSide
    {
        Height,
        LeftWidth,
        RightWidth
    }
    
}