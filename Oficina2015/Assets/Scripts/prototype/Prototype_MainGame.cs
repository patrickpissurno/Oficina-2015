using UnityEngine;
using System.Collections;

public class Prototype_MainGame : MonoBehaviour {

    public static bool SoundEnabled = true;
    public static Rota.Level Level = null;
    public static int Timer = 10;
    public static Prototype_MainGame instance;

    public enum Side
    {
        Left = -1,
        Center = 0,
        Right = 1
    }

    void Awake()
    {
        instance = this;
        Prototype_Move.Character = Rota.GetCharacters()[0];
    }

	void Start () {
        SoundController._PlayBG("main");
        if (Level != null)
        {
            Prototype_Stage.BaseSpeed = Level.Speed;
            Timer = Level.Timer;
        }
        StartCoroutine(TimerRoutine());
	}

    IEnumerator TimerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Timer--;
            if (Timer <= 0)
            {
                Win();
                break;
            }
        }
    }

    public void Win()
    {
        Application.LoadLevel("GameWin");
    }

    public void Loose()
    {
        Application.LoadLevel("GameOver");
    }
}
