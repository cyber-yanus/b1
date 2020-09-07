using DefaultNamespace;
using UnityEngine;

public class ConnectCheck : MonoBehaviour
{
    private BojoRay _upRay;
    private BojoRay _downRay;
    private BojoRay _leftRay;
    private BojoRay _rightRay;
    private BojoRay _backRay;
    private BojoRay _forwardRay;

    private float _rayDistance = 0.001f;
    
    
    private Hero _hero;
    
    
    
    void Start()
    {
        CalculateRayDistance();
        InitRay();
    }


    private void InitRay()
    {
        // это всё надо убрать
        Vector3 origin = transform.position;
        
        _upRay = new BojoRay(origin, Vector3.up, _rayDistance);
        _downRay = new BojoRay(origin, Vector3.down, _rayDistance);

        _leftRay = new BojoRay(origin, Vector3.left, _rayDistance);
        _rightRay = new BojoRay(origin, Vector3.right, _rayDistance);
        
        _backRay = new BojoRay(origin, Vector3.back, _rayDistance);
        _forwardRay = new BojoRay(origin, Vector3.forward, _rayDistance);
    }

    private void CalculateRayDistance()
    {
        float innerDistance = 1f;
        _rayDistance += innerDistance;
    }

    private void drawRays()
    {
        foreach (var bojoRay in BojoRay.BojoRays)
            bojoRay.DrawRay();
    }

    private void CheckHit()
    {
        foreach (var bojoRay in BojoRay.BojoRays)
        {
            Ray ray = bojoRay.Ray;
            
            if (Physics.Raycast(ray, out var hit, _rayDistance))
            {
                if (hit.transform.tag.Equals("Player"))
                {
                    Debug.Log("connect with player");
                    _hero = hit.transform.GetComponent<Hero>();
                    _hero.ConnectCube(transform, bojoRay.SideType);
                }
            }
        }
       
    }
    
    
    private void FixedUpdate()
    {
        drawRays();
        BojoRay.UpdateStartPosition(transform.position);
        CheckHit();
    }

    

}
