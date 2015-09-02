using UnityEngine;
using System.Collections;

public class Prototype_CameraFollow : MonoBehaviour {

    public static GameObject Target = null;

	void FixedUpdate () {
        if (Target != null)
        {
            Vector3 nextPosition = new Vector3(Target.transform.position.x * .7f, this.transform.position.y, this.transform.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position, nextPosition, .6f);
        }
	}
}
