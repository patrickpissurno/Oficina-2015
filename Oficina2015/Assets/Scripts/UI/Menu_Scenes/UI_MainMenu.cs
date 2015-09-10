using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_MainMenu : MonoBehaviour {

    public Sprite[] SoundSprites;
    public Image SoundImage;

    public void ToggleSound()
    {
        Prototype_MainGame.SoundEnabled = !Prototype_MainGame.SoundEnabled;
        SoundImage.sprite = SoundSprites[(Prototype_MainGame.SoundEnabled ? 1 : 0)];
    }

    public void Play()
    {
        Application.LoadLevel("Game");
    }

    public void Help()
    {
        Application.LoadLevel("Help");
    }

    public void About()
    {
        Application.LoadLevel("About");
    }

}
