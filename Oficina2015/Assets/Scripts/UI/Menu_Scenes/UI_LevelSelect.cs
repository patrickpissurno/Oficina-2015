using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class UI_LevelSelect : MonoBehaviour {

    void Start()
    {
        LevelController.LevelControllers = LevelController.LevelControllers.OrderBy(o => o.gameObject.name).ToList();
        Rota.Level[] levels = Rota.instance.Levels;
        for (int i = 0; i < levels.Length && i < LevelController.LevelControllers.Count; i++)
        {
            LevelController l = LevelController.LevelControllers[i];
            l.Id = i;
            l.StarAmount = levels[i].Stars;
            l.Locked = i > Rota.LevelUnlock;
            l.Start();
        }
    }

    public void Play(GameObject obj)
    {
        LevelController l = obj.GetComponent<LevelController>();
        SoundController._PlayFX("click");
        if (!l.Locked)
        {
            Prototype_MainGame.Level = Rota.instance.Levels[l.Id];
            LoadLevel("Game");
        }
    }

    public void Back()
    {
        SoundController._PlayFX("click");
        LoadLevel("MainMenu");
    }

    public void LoadLevel(string name)
    {
        LevelController.LevelControllers = null;
        Application.LoadLevel(name);
    }
}
