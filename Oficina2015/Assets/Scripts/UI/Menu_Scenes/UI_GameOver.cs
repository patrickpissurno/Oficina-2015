using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_GameOver : MonoBehaviour {

    public void MainMenu()
    {
        Application.LoadLevel("MainMenu");
    }

    public void Restart()
    {
        Application.LoadLevel("Game");
    }

}
