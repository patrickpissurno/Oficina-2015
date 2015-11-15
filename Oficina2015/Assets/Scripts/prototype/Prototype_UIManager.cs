using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Prototype_UIManager : MonoBehaviour {

    public Text TimerLabel;
    public Text DistanceLabel;

	void Update () {
        this.TimerLabel.text = Prototype_MainGame.Timer.ToString();
        this.DistanceLabel.text = Mathf.Floor(Prototype_MainGame.Distance).ToString() + "m";
	}
}
