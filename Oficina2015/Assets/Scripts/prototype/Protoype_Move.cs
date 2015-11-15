using UnityEngine;
using System.Collections;

public class Protoype_Move : MonoBehaviour 
{
	public Sprite[] Esquerda;
	public Sprite[] Direita;
	public Sprite[] Centro;
	private int AtualPosition;
	public GameObject[] Points;
    private int CurrentFrame = 0;
    public float ImageSpeed = .2f;
    private bool isJumping = false;
    private new BoxCollider collider;

    public int PositionAtual
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
		if(transform.position != Points[AtualPosition].transform.position)
		{
			transform.position = Vector3.Lerp(transform.position, Points[AtualPosition].transform.position, 0.4f);
		}
	}

    IEnumerator Anim()
    {
        while (true)
        {
            if (CurrentFrame < Direita.Length-1)
                CurrentFrame++;
            else
                CurrentFrame = 0;

            switch (AtualPosition)
            {
                case 0:
                    gameObject.GetComponent<SpriteRenderer>().sprite = Direita[CurrentFrame];
                    break;
                case 1:
                    gameObject.GetComponent<SpriteRenderer>().sprite = Centro[CurrentFrame];
                    break;
                case 2:
                    gameObject.GetComponent<SpriteRenderer>().sprite = Esquerda[CurrentFrame];
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
            StartCoroutine(_Jump());
        }
    }

    private IEnumerator _Jump()
    {
        this.collider.enabled = false;
        yield return new WaitForSeconds(.5f);
        this.collider.enabled = true;
        this.isJumping = false;
    }
}
