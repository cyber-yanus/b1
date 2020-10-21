using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Gradient
{
    public class LevelList : MonoBehaviour
    {
        [SerializeField] private float step;
        [SerializeField] private List<Level> leves;
        
        private Level _currentLevel;
        private int _currentLevelNumber = -1;

        private void Start()
        {
            LoadLevel();
        }

        public void LoadLevel()
        {
            _currentLevelNumber++;
            _currentLevel = leves[_currentLevelNumber];
            
            _currentLevel.Appearance();   
        }

        public void LoadNewLevel()
        {
            _currentLevel.Disappearance();
            
            float positionY = transform.localPosition.y + step;
            transform.DOLocalMoveY(positionY, 2f);
        }

    }
}