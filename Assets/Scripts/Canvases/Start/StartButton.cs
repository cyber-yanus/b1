using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Canvases.Start
{
    public class StartButton : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private Hero hero;
        
        private GameObject _startCanvas;
        
        
        private void Start()
        {
            _startCanvas = transform.parent.gameObject;
            
            Button button = GetComponent<Button>();
            button.onClick.AddListener(Execute);
        }


        private void Execute()
        {
            camera.DOOrthoSize(10f, 1f).OnComplete(HeroActivate);
            _startCanvas.SetActive(false);
        }

        private void HeroActivate()
        {
            hero.gameObject.SetActive(true);
        }

    }
}