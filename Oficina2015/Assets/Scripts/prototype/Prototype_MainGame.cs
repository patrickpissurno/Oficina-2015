using UnityEngine;
using System.Collections;

public class Prototype_MainGame : MonoBehaviour {

    public enum Side
    {
        Left = -1,
        Center = 0,
        Right = 1
    }

	void Start () {
        Prototype_Stage.BaseSpeed = .3f;
        StartCoroutine(Timer());
	}

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Prototype_Stage.BaseSpeed += .05f;
        }
    }
}
