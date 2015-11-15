using UnityEngine;
using System.Collections;

public class Prototype_Swype : MonoBehaviour 
{
    private Prototype_Move PlayerMove;
    private float InitialPoint;
    private float InitialPointY;
    private float EndPoint;
    private float EndPointY;
    private bool CanCalculate;
    private bool CanCount;
    private float Counter;

	void Start () 
    {
        InitialPoint = 0;
        EndPoint = 0;
        CanCalculate = false;
        PlayerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<Prototype_Move>();
	}
	void Update () 
    {
	    if(CanCalculate)
        {
            CanCalculate = false;
            if (Mathf.Abs(EndPoint - InitialPoint) > Mathf.Abs(EndPointY - InitialPointY))
            {
                if (InitialPoint > EndPoint)
                {
                    PlayerMove.ActualPosition -= 1;
                }
                else if (InitialPoint != EndPoint)
                {
                    PlayerMove.ActualPosition += 1;
                }
            }
            else
            {
                if (InitialPointY < EndPointY)
                    PlayerMove.Jump();
            }

            InitialPoint = 0;
            EndPoint = 0;
            InitialPointY = 0;
            EndPointY = 0;
        }
        if(CanCount)
        {
            Counter += Time.deltaTime;
        }
        if(Counter > 0.75f)
        {
            CanCount = false;
            Counter = 0f;
            EndPoint = Input.GetTouch(0).position.x;
            EndPointY = Input.GetTouch(0).position.y;
            CanCalculate = true;
        }
	}
    void OnMouseDown()
    {
        CanCount = true;
        InitialPoint = Input.GetTouch(0).position.x;
        InitialPointY = Input.GetTouch(0).position.y;
    }
    
    void OnMouseUp()
    {
        if(CanCount)
        {
            CanCount = false;
            Counter = 0f;
            EndPoint = Input.GetTouch(0).position.x;
            EndPointY = Input.GetTouch(0).position.y;
            CanCalculate = true;
        }
    }
}
