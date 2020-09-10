using System.Collections;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;


public class MoveHero : MonoBehaviour
{
    private Rigidbody _rb;

    private Sequence _sequence;
    private Tween _jumpTween;
    private Tween _rotateFlip;
    
    private FigureSize _figureSize;
    
    private float _jumpDuration = 0.5f;
    private float _rotateDuration = 0.25f;
    
    private float _positionYForJump;
    private float _positionZForJump;
    private float _positionXForJump;
    
    [SerializeField] private bool isMoved;
    [SerializeField] private float moveStep = 2f;
    [SerializeField] private float jumpPower = 4f;
    [SerializeField] private MoveDirection moveDirection = MoveDirection.Right;
    [SerializeField] private Transform pivot;
    
    
    
    void Start()
    {
        _figureSize = GetComponent<FigureSize>();
        _rb = GetComponent<Rigidbody>();
        
        _sequence = DOTween.Sequence();
        
        //проинициализировать твины
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
        moveStep = _figureSize.HeightSide;
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
        float groundPositionY = 1f;
            
        if (_figureSize.WidthCubeCount % 2 == 0)
        {
            _positionYForJump = groundPositionY + _figureSize.WidthCubeCount + 1;
        }
        else
        {
            _positionYForJump = groundPositionY + _figureSize.WidthCubeCount;    
        }
        
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
        Vector3 newMovePosition = new Vector3(_positionXForJump, _positionYForJump, _positionZForJump);

        _jumpTween = _rb.DOJump(newMovePosition, jumpPower, 0, _jumpDuration);
        _sequence.Join(_jumpTween).SetEase(Ease.InOutFlash);

    }

    private void Rotate()
    {
//        Vector3 newRotatePosition = Vector3.zero;
//        
//        if (moveDirection == MoveDirection.Right)
//        {
//            newRotatePosition = new Vector3(90, 0, 0);    
//        }
//        else if(moveDirection == MoveDirection.Left)
//        {
//            newRotatePosition = new Vector3(0, 0, 90);
//        }
//
//        _rotateFlip = transform.DORotate(newRotatePosition, _rotateDuration, RotateMode.WorldAxisAdd);
//        _sequence.Join(_rotateFlip);

        
        

    }

    private void Update()
    {
        if (_jumpTween !=null)
            isMoved = _jumpTween.IsPlaying();
        
        
        transform.RotateAround(pivot.position, Vector3.right, 90f * Time.deltaTime);
    }
    
    
    
    public MoveDirection MoveDirection
    {
        get => moveDirection;
        set => moveDirection = value;
    }
    public bool IsMoved => isMoved;
}
