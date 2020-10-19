using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Gradient
{
    public class ColorChangeover : MonoBehaviour
    {
        [SerializeField] private float gardientDuration;
        [SerializeField] private List<Color> colors; 
        
        private Image image;
        private int currentColorNumber;
        
        
        
        private void Start()
        {
            image = GetComponent<Image>();
            Go();
        }


        private void Go()
        {
            if (currentColorNumber == colors.Count)
                currentColorNumber = 0;
            
            image.DOColor(colors[currentColorNumber], gardientDuration).OnComplete(Go);
            currentColorNumber++;
        }
    }
}