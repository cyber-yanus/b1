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

        

        public void InitCubeCount(Swipes swipeDirection)
        {
            heightCubeCount = heightSide; 
            
            if (swipeDirection == Swipes.TopLeft || swipeDirection == Swipes.BottomRight)
            {
                widthCubeCount = leftWidthSide;
            }
            else if (swipeDirection == Swipes.TopRight || swipeDirection == Swipes.BottomLeft)
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
        
        public void Smena(Swipes swipeDirection)
        {
            int saveFigureCount = widthCubeCount;
            
            if (swipeDirection == Swipes.TopLeft || swipeDirection == Swipes.BottomRight)
            {
                leftWidthSide = widthCubeCount = heightSide;
            }
            else if (swipeDirection == Swipes.TopRight || swipeDirection == Swipes.BottomLeft)
            {
                rightWidthSide = widthCubeCount = heightSide;
            }
            
            heightSide = heightCubeCount = saveFigureCount;
        }

        
        public int WidthCubeCount => widthCubeCount;
        public int HeightCubeCount => heightCubeCount;

        public int HeightSide => heightSide;
        public int LeftWidthSide => leftWidthSide;
        public int RightWidthSide => rightWidthSide;
    }
    
    
    public enum ConnectSide
    {
        Height,
        LeftWidth,
        RightWidth
    }
    
}