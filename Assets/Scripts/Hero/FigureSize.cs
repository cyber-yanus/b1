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
        
        private int _widthCubeCount = 1;
        private int _heightCubeCount = 1;

        

        public void InitCubeCount(Swipes swipeDirection)
        {
            _heightCubeCount = heightSide; 
            
            if (swipeDirection == Swipes.TopLeft || swipeDirection == Swipes.BottomRight)
            {
                _widthCubeCount = leftWidthSide;
            }
            else if (swipeDirection == Swipes.TopRight || swipeDirection == Swipes.BottomLeft)
            {
                _widthCubeCount = rightWidthSide;
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

        public void RemoveEllementFromArray(ConnectSide connectSide)
        {
            switch (connectSide)
            {
                case ConnectSide.Height:
                    heightSide--;
                    break;
                
                case ConnectSide.LeftWidth:
                    leftWidthSide--;
                    break;
                
                case ConnectSide.RightWidth:
                    rightWidthSide--;
                    break;
            }
        }

        public void Smena(Swipes swipeDirection)
        {
            int saveFigureCount = _widthCubeCount;
            
            if (swipeDirection == Swipes.TopLeft || swipeDirection == Swipes.BottomRight)
            {
                leftWidthSide = _widthCubeCount = heightSide;
            }
            else if (swipeDirection == Swipes.TopRight || swipeDirection == Swipes.BottomLeft)
            {
                rightWidthSide = _widthCubeCount = heightSide;
            }
            
            heightSide = _heightCubeCount = saveFigureCount;
        }

        
        public int WidthCubeCount => _widthCubeCount;
        public int HeightCubeCount => _heightCubeCount;

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