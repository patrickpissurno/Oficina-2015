using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_MainMenu : MonoBehaviour {

    public Sprite[] SoundSprites;
    public Image SoundImage;

    void Start()
    {
        SoundController._PlayBG("main");
    }

    public void ToggleSound()
    {
        Prototype_MainGame.SoundEnabled = !Prototype_MainGame.SoundEnabled;
        SoundImage.sprite = SoundSprites[(Prototype_MainGame.SoundEnabled ? 1 : 0)];
    }

    public void Play()
    {
        SoundController._PlayFX("click");
        Application.LoadLevel("Game");
    }

    public void Help()
    {
        SoundController._PlayFX("click");
        Application.LoadLevel("Help");
    }

    public void About()
    {
        SoundController._PlayFX("click");
        Application.LoadLevel("About");
    }

}
