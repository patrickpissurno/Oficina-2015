using UnityEngine;
using System.Collections;

public class Prototype_MainGame : MonoBehaviour {

    public static int Timer = 0;

    public enum Side
    {
        Left = -1,
        Center = 0,
        Right = 1
    }

	void Start () {
        Prototype_Stage.BaseSpeed = .3f;
        Timer = 0;
        StartCoroutine(TimerRoutine());
	}

    IEnumerator TimerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Prototype_Stage.BaseSpeed += .05f;
            Timer++;
        }
    }
}
