using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_GameWin : MonoBehaviour {

    private Sprite[] AnimSprites;
    public Image AnimImage;

    void Start()
    {
        /*SoundController._PlayFX("cutscene1");
        AnimSprites = Resources.LoadAll<Sprite>("Cutscenes/Bus");
        StartCoroutine(Anim());
        Application.LoadLevel("MainMenu");*/
        Invoke("DoPlay", 1.0f);
    }

    void DoPlay()
    {
        Handheld.PlayFullScreenMovie("Cutscene_Win.mp4", Color.black, FullScreenMovieControlMode.Hidden);
    }

    IEnumerator Anim()
    {
        foreach (Sprite frame in AnimSprites)
        {
            AnimImage.sprite = frame;
            yield return new WaitForSeconds(.03f);
        }
        Application.LoadLevel("MainMenu");
    }

}
