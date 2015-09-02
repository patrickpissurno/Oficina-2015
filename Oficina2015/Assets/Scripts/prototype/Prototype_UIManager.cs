using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Prototype_UIManager : MonoBehaviour {

    public Text TimerLabel;

	void Update () {
        this.TimerLabel.text = Prototype_MainGame.Timer.ToString();
	}
}
