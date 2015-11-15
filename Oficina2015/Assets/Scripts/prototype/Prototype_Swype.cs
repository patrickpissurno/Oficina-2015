using UnityEngine;
using System.Collections;

public class Prototype_Swype : MonoBehaviour 
{
    private Prototype_Move PlayerMove;
    private float InitialPoint;
    private float EndPoint;
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
            if(InitialPoint > EndPoint)
            {
                PlayerMove.PositionAtual -= 1;
            }
            else if(InitialPoint != EndPoint)
            {
                PlayerMove.PositionAtual += 1;
            }
            InitialPoint = 0;
            EndPoint = 0;
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
            CanCalculate = true;
        }
	}
    void OnMouseDown()
    {
        CanCount = true;
        InitialPoint = Input.GetTouch(0).position.x;
    }
    
    void OnMouseUp()
    {
        if(CanCount)
        {
            CanCount = false;
            Counter = 0f;
            EndPoint = Input.GetTouch(0).position.x;
            CanCalculate = true;
        }
    }
}
