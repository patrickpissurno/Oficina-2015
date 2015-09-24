using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_GameOver : MonoBehaviour {
	
	public Text score;
	void Start()
	{
		score.text = "" + (90-Prototype_MainGame.Timer) + "s";
	}
	
    public void MainMenu()
    {
        Application.LoadLevel("MainMenu");
    }

    public void Restart()
    {
        Application.LoadLevel("Game");
    }

}
