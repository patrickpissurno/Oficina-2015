using UnityEngine;
using System.Collections;

public class Protoype_Move : MonoBehaviour 
{
	public Sprite[] Esquerda;
	public Sprite[] Direita;
	public Sprite[] Centro;
	public int AtualPosition;
	public GameObject[] Points;
	
	void Start () 
	{
		AtualPosition = 1;
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
			transform.position = Vector3.Lerp(transform.position, Points[AtualPosition].transform.position, 0.5f);
		}
		switch(AtualPosition)
		{
			case 0:
				for(int i = 0; i < Direita.Length; i++)
				{
					gameObject.GetComponent<SpriteRenderer>().sprite = Direita[i];
				}
			break;
			case 1:
				for(int i = 0; i < Centro.Length; i++)
				{
					gameObject.GetComponent<SpriteRenderer>().sprite = Centro[i];
				}
			break;
			case 2:
				for(int i = 0; i < Esquerda.Length; i++)
				{
					gameObject.GetComponent<SpriteRenderer>().sprite = Esquerda[i];
				}
			break;
		}
	}
}
