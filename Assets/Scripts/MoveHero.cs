using System.Collections;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;


public class MoveHero : MonoBehaviour
{
    private Hero _hero;
    
    private Rigidbody _rb;

    private Sequence _sequence;

    private FigureSize _figureSize;
    
    private float _jumpDuration = 0.5f;
    private float _rotateDuration = 0.25f;
    
    private float _positionYForJump;
    private float _positionZForJump;
    private float _positionXForJump;
    
    [SerializeField] private float moveStep = 2f;
    [SerializeField] private float jumpPower = 4f;
    [SerializeField] private MoveDirection moveDirection = MoveDirection.Right;
    
    
    
    
    void Start()
    {
        _figureSize = GetComponent<FigureSize>();
        _hero = GetComponent<Hero>();
        _rb = GetComponent<Rigidbody>();
        
        _sequence = DOTween.Sequence();

//        StartCoroutine(Move());
        
    }
/*
    IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            
            //определяем, какая грань дует шириной фигуры
            _figureSize.InitCubeCount(moveDirection);
            
            CalculateMoveStep();
            CalculateEndPositionForJump();
            
            Jump();    
            Rotate();

            //меняем значения высоты и ширны между собой 
            _figureSize.Smena();
        }
    }
*/

    public void Move(MoveDirection moveDirection)
    {
        this.moveDirection = moveDirection; 
        
        //определяем, какая грань дует шириной фигуры
        _figureSize.InitCubeCount(moveDirection);
            
        CalculateMoveStep();
        CalculateEndPositionForJump();
            
        Jump();    
        Rotate();

        //меняем значения высоты и ширны между собой 
        _figureSize.Smena();
    }

    private void CalculateMoveStep()
    {
        moveStep = 2f * _figureSize.WidthCubeCount;
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
        float groundPositionY = 2f;
        _positionYForJump = groundPositionY + _figureSize.WidthCubeCount;
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
        _sequence.Join(_rb.DOJump(newMovePosition, jumpPower, 0, _jumpDuration)).SetEase(Ease.InOutFlash);

    }

    private void Rotate()
    {
        Vector3 newRotatePosition = Vector3.zero;
        
        if (moveDirection == MoveDirection.Right)
        {
            newRotatePosition = new Vector3(90, 0, 0);    
        }
        else if(moveDirection == MoveDirection.Left)
        {
            newRotatePosition = new Vector3(0, 0, 90);
        }
        
        _sequence.Join(transform.DORotate(newRotatePosition, _rotateDuration, RotateMode.WorldAxisAdd));
    }


    public MoveDirection MoveDirection
    {
        get => moveDirection;
        set => moveDirection = value;
    }
}
