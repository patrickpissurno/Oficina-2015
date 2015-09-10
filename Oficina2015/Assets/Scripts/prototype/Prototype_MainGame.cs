using UnityEngine;
using System.Collections;

public class Prototype_MainGame : MonoBehaviour {

    public static bool SoundEnabled = true;

    public static int Timer = 0;
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
    }

	void Start () {
        Prototype_Stage.BaseSpeed = 1f;
        Timer = 120;
        StartCoroutine(TimerRoutine());
	}

    IEnumerator TimerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            //Prototype_Stage.BaseSpeed += .05f;
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
