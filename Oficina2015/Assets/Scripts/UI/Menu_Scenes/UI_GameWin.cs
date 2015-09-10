﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_GameWin : MonoBehaviour {

    private Sprite[] AnimSprites;
    public Image AnimImage;

    void Start()
    {
        AnimSprites = Resources.LoadAll<Sprite>("Cutscenes/Bus");
        StartCoroutine(Anim());
    }

    IEnumerator Anim()
    {
        foreach (Sprite frame in AnimSprites)
        {
            AnimImage.sprite = frame;
            yield return new WaitForSeconds(.1f);
        }
        Application.LoadLevel("MainMenu");
    }

}