using UnityEngine;
using System.Collections;

public class Prototype_Move : MonoBehaviour 
{
    public static Rota.Character Character;
	private int AtualPosition;
	public GameObject[] Points;
    private int CurrentFrame = 0;
    public float ImageSpeed = .2f;
    private bool isJumping = false;
    private new BoxCollider collider;

    public int ActualPosition
    {
        get
        {
            return this.AtualPosition;
        }
        set
        {
            if (this.AtualPosition < 0)
            {
                this.AtualPosition = 0;
            }
            else if (this.AtualPosition > 2)
            {
                this.AtualPosition = 2;
            }
            else
            {
                this.AtualPosition = value;
            }
        }
    }
	void Start () 
	{
        this.collider = this.GetComponent<BoxCollider>();
        Prototype_CameraFollow.Target = this.gameObject;
		AtualPosition = 1;
        StartCoroutine(Anim());
	}
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.LeftArrow) && AtualPosition > 0) 
		{
			AtualPosition -= 1;
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow) && AtualPosition < 2) 
		{
			AtualPosition += 1;
		}
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        Vector3 TargetPos = new Vector3(Points[AtualPosition].transform.position.x, (isJumping ? Points[3] : Points[AtualPosition]).transform.position.y, Points[AtualPosition].transform.position.z);
		if(transform.position != TargetPos)
		{
			transform.position = Vector3.Lerp(transform.position, TargetPos, 0.4f);
		}
	}

    IEnumerator Anim()
    {
        while (true)
        {
            if (CurrentFrame < (this.isJumping ? Character.Jump_Right : Character.Walk_Right).Length-1)
                CurrentFrame++;
            else if (!this.isJumping)
                CurrentFrame = 0;

            switch (AtualPosition)
            {
                case 0:
                    gameObject.GetComponent<SpriteRenderer>().sprite = this.isJumping ? Character.Jump_Right[CurrentFrame] : Character.Walk_Right[CurrentFrame];
                    break;
                case 1:
                    gameObject.GetComponent<SpriteRenderer>().sprite = this.isJumping ? Character.Jump_Center[CurrentFrame] : Character.Walk_Center[CurrentFrame];
                    break;
                case 2:
                    gameObject.GetComponent<SpriteRenderer>().sprite = this.isJumping ? Character.Jump_Left[CurrentFrame] : Character.Walk_Left[CurrentFrame];
                    break;
            }
            yield return new WaitForSeconds(ImageSpeed/Prototype_Stage.BaseSpeed);
        }
    }

    public void Jump()
    {
        if (!this.isJumping)
        {
            this.isJumping = true;
            CurrentFrame = 0;
            StartCoroutine(_Jump());
        }
    }

    private IEnumerator _Jump()
    {
        this.collider.enabled = false;
        this.ImageSpeed *= 2;
        yield return new WaitForSeconds(.5f);
        this.ImageSpeed /= 2;
        this.collider.enabled = true;
        this.isJumping = false;
    }
}
