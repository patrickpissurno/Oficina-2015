using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_About : MonoBehaviour {

    public void Back()
    {
        Fade.LoadLevel("MainMenu");
        SoundController._PlayFX("click");
    }

}
