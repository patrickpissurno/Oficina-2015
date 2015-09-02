using UnityEngine;
using System.Collections;

public class Prototype_LookToCamera : MonoBehaviour {
	void Update () {
        this.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
	}
}
