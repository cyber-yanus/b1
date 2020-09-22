using System.Collections;
using DefaultNamespace;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;


public class MoveHero : MonoBehaviour
{
    private Sequence _sequence;
    private Tween _jumpTween;
    private Tween _rotateTween;
    
    private FigureSize _figureSize;
    
    private float _jumpDuration = 0.25f;
    private float _rotateDuration = 0.25f;
  
    private float _positionXForJump;
    private float _positionYForJump;
    private float _positionZForJump;
  
    
    
    
    [SerializeField] private bool isMoved;
    [SerializeField] private float moveStep;
    [SerializeField] private float jumpPower = 4f;
    [SerializeField] private Swipes moveDirection;
    
    
    
    void Start()
    {
        _figureSize = GetComponent<FigureSize>();
        
        _sequence = DOTween.Sequence();
    }

    public void Move(Swipes swipeDirection)
    {
        if (!isMoved)
        {
            moveDirection = swipeDirection;

            //определяем, какая грань дует шириной фигуры
            _figureSize.InitCubeCount(swipeDirection);

            CalculateMoveStep();
            CalculateEndPositionForJump();

            Jump();
            Rotate();

            //меняем значения высоты и ширны между собой 
            _figureSize.Smena(swipeDirection);
        }
    }

    private void CalculateMoveStep()
    {
        float halfHeight = _figureSize.HeightCubeCount / 2f;
        float halfWidth = _figureSize.WidthCubeCount / 2f;

        moveStep = halfWidth + halfHeight;

    }

    private void CalculateEndPositionForJump()
    {
        PositionXForJump();
        PositionYForJump();
        PositionZForJump();
    }

    private void PositionXForJump()
    {    
         if(moveDirection == Swipes.TopLeft)
            _positionXForJump = transform.position.x  - moveStep;
         else if(moveDirection == Swipes.BottomRight)
            _positionXForJump = transform.position.x  + moveStep;
         else 
             _positionXForJump = transform.position.x;
        
    }

    private void PositionYForJump()
    {
        float ground = 0.5f;
        _positionYForJump = ground + _figureSize.WidthCubeCount / 2f;    
    }
   
    private void PositionZForJump()
    {
        if (moveDirection == Swipes.TopRight)
            _positionZForJump = transform.position.z + moveStep;
        else if(moveDirection == Swipes.BottomLeft)
            _positionZForJump = transform.position.z - moveStep;
        else 
            _positionZForJump = transform.position.z;
    }

    private void Jump()
    {
        Vector3 endPosition = new Vector3(_positionXForJump, _positionYForJump, _positionZForJump);

        _jumpTween = transform.DOJump(endPosition, jumpPower, 0, _jumpDuration).SetEase(Ease.InOutFlash);
        _sequence.Join(_jumpTween);
    }

    private void Rotate()
    {
        Vector3 endPosition = Vector3.zero;

        switch (moveDirection)
        {
            case Swipes.TopRight:
                endPosition = new Vector3(90, 0, 0);
                break;
                
            case Swipes.TopLeft:
                endPosition = new Vector3(0, 0, 90);
                break;
            
            case Swipes.BottomLeft:
                endPosition = new Vector3(-90, 0, 0);
                break;
            
            case Swipes.BottomRight:
                endPosition = new Vector3(0, 0, -90);
                break;
        }
        
        _rotateTween = transform.DORotate(endPosition, _rotateDuration, RotateMode.WorldAxisAdd);
        _sequence.Join(_rotateTween);
    }

    private void Update()
    {
        if (_jumpTween != null)
        {
            isMoved = _jumpTween.IsPlaying();
        }
       
    }


    public void removeJumpTween()
    {
        _jumpTween.Kill();
    }

    public Swipes MoveDirection
    {
        get => moveDirection;
        set => moveDirection = value;
    }
    public bool IsMoved => isMoved;


    public float PositionXForJump1 => _positionXForJump;
    public float PositionYForJump1 => _positionYForJump;
    public float PositionZForJump1 => _positionZForJump;
    
}
