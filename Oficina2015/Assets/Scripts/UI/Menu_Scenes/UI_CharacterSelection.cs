using UnityEngine;
using System.Collections;

public class UI_CharacterSelection : MonoBehaviour {

    public void Back()
    {
        Fade.LoadLevel("MainMenu");
        SoundController._PlayFX("click");
    }

    public void SelectCharacter(int id)
    {
        Prototype_Move.Character = Rota.GetCharacters()[id];
        SoundController._PlayFX("click");
        Fade.LoadLevel("LevelSelect");
    }
}
