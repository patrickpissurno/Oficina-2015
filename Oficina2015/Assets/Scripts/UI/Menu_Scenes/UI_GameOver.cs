using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_GameOver : MonoBehaviour {
	
	public Text score;
	void Start()
	{
        SoundController._PlayBG("none");
        SoundController._PlayFX("loose");
		score.text = "" + (90-Prototype_MainGame.Timer) + "s";
	}
	
    public void MainMenu()
    {
        SoundController._PlayFX("click");
        Application.LoadLevel("MainMenu");
    }

    public void Restart()
    {
        SoundController._PlayFX("click");
        Application.LoadLevel("Game");
    }

}
