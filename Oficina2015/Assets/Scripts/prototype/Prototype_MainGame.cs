using UnityEngine;
using System.Collections;

public class Prototype_MainGame : MonoBehaviour {

    public static bool SoundEnabled = true;
    public static Rota.Level Level = null;
    public static int Timer = 10;
    public static float Distance = 50;
    public static Prototype_MainGame instance;
    public Prototype_Enemy.CollisionAction ActiveEffect = Prototype_Enemy.CollisionAction.None;

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
            Distance = Level.Distance;
        }
        StartCoroutine(TimerRoutine());
	}

    void Update()
    {
        Distance -= Time.deltaTime * 3f * Level.Speed;
        if (Distance <= 0)
            Win();
    }

    IEnumerator TimerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Timer--;
            if (Distance <= 0)
                break;
            if (Timer <= 0)
            {
                Loose();
                break;
            }
        }
    }

    IEnumerator DisableEffect(float duration, Prototype_Enemy.CollisionAction action)
    {
        yield return new WaitForSeconds(duration);
        if (ActiveEffect == action)
        {
            Prototype_Stage.BaseSpeed = Level.Speed;
            ActiveEffect = Prototype_Enemy.CollisionAction.None;
        }
    }

    public void SetSlow()
    {
        if (ActiveEffect == Prototype_Enemy.CollisionAction.None || ActiveEffect != Prototype_Enemy.CollisionAction.Slow)
        {
            Prototype_Stage.BaseSpeed = Level.Speed * .5f;
            StartCoroutine(DisableEffect(1.5f, Prototype_Enemy.CollisionAction.Slow));
            ActiveEffect = Prototype_Enemy.CollisionAction.Slow;
            Debug.Log("SLOW");
        }
    }

    public void SetSpeed()
    {
        if (ActiveEffect == Prototype_Enemy.CollisionAction.None || ActiveEffect != Prototype_Enemy.CollisionAction.Speed)
        {
            Prototype_Stage.BaseSpeed = Level.Speed * 2f;
            StartCoroutine(DisableEffect(1.5f, Prototype_Enemy.CollisionAction.Speed));
            ActiveEffect = Prototype_Enemy.CollisionAction.Speed;
            Debug.Log("SPEED");
        }
    }

    public void Win()
    {
        int score = Mathf.FloorToInt(3f * Timer / Level.TargetTimer);
        score = score > 3 ? 3 : score;
        Level.Stars = score;
        PlayerPrefs.SetInt("Stars_" + Level.Id, score);
        Rota.LevelUnlock = Rota.LevelUnlock <= Level.Id ? Level.Id + 1: Rota.LevelUnlock;
        PlayerPrefs.SetInt("LevelUnlock", Rota.LevelUnlock);
        Application.LoadLevel("GameWin");
    }

    public void Loose()
    {
        Application.LoadLevel("GameOver");
    }
}
