using System;
using UnityEngine;
using UnityEngine.Serialization;


public class MoveHero : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Rigidbody _rb;
    private Vector3 _force;
    
    public bool isMove;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    public void AddDirection(String  direction)
    {

        if (!isMove)
        {
            isMove = true;

            switch (direction)
            {
                case "B":
                    Debug.Log("Back");
                    _force = transform.forward * -1 * speed / Time.fixedDeltaTime;
                    break;

                case "R":
                    Debug.Log("Right");
                    _force = transform.right * speed / Time.fixedDeltaTime;
                    break;

                case "F":
                    Debug.Log("Forward");
                    _force = transform.forward * speed / Time.fixedDeltaTime;
                    break;

                case "L":
                    Debug.Log("Left");
                    _force = transform.right * -1 * speed / Time.fixedDeltaTime;
                    break;
            }
        }
    }

    private void FixedUpdate()
    {
        if(isMove)
            Move();
    }

    private void Move()
    {
        _rb.AddForce(_force);
    }
}

