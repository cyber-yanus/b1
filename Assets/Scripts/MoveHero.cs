using System.Collections;
using DefaultNamespace;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;


public class MoveHero : MonoBehaviour
{
    private Rigidbody _rb;

    private Sequence _sequence;
    private Tween _jumpTween;
    private Tween _rotateTween;
    
    private FigureSize _figureSize;
    
    private float _jumpDuration = 0.5f;
    private float _rotateDuration = 0.25f;
  
    private float _positionXForJump;
    private float _positionYForJump;
    private float _positionZForJump;
  
    
    
    
    [SerializeField] private bool isMoved;
    [SerializeField] private float moveStep;
    [SerializeField] private float jumpPower = 4f;
    [SerializeField] private MoveDirection moveDirection = MoveDirection.Right;
    
    
    
    void Start()
    {
        _figureSize = GetComponent<FigureSize>();
        _rb = GetComponent<Rigidbody>();
        
        _sequence = DOTween.Sequence();
    }

    public void Move(MoveDirection moveDirection)
    {
        if (!isMoved)
        {
            this.moveDirection = moveDirection;

            //определяем, какая грань дует шириной фигуры
            _figureSize.InitCubeCount(moveDirection);

            CalculateMoveStep();
            CalculateEndPositionForJump();

            Jump();
            Rotate();

            //меняем значения высоты и ширны между собой 
            _figureSize.Smena(moveDirection);
        }
    }

    private void CalculateMoveStep()
    {
        float ground = 0.5f;
        moveStep = _figureSize.GetMaxSize() / 2f + ground;
    }

    private void CalculateEndPositionForJump()
    {
        PositionXForJump();
        PositionYForJump();
        PositionZForJump();
    }

    private void PositionXForJump()
    {
        if (moveDirection == MoveDirection.Right)
            _positionXForJump = transform.position.x;    
        else if(moveDirection == MoveDirection.Left)
            _positionXForJump = transform.position.x  - moveStep;
        
    }

    private void PositionYForJump()
    {
        float ground = 0.5f;
        _positionYForJump = ground + _figureSize.WidthCubeCount / 2f;    
    }
   
    private void PositionZForJump()
    {
        if (moveDirection == MoveDirection.Right)
            _positionZForJump = transform.position.z + moveStep;    
        else if(moveDirection == MoveDirection.Left)
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

        
        if (moveDirection == MoveDirection.Right)
        {
            endPosition = new Vector3(90, 0, 0);    
        }
        else if(moveDirection == MoveDirection.Left)
        {
            endPosition = new Vector3(0, 0, 90);
        }
        
        _rotateTween = transform.DORotate(endPosition, _rotateDuration, RotateMode.WorldAxisAdd);
        _sequence.Join(_rotateTween);
    }

    private void Update()
    {
        if (_jumpTween !=null)
            isMoved = _jumpTween.IsPlaying();
    }
    
    
    
    
    public MoveDirection MoveDirection
    {
        get => moveDirection;
        set => moveDirection = value;
    }
    public bool IsMoved => isMoved;
}
