using UnityEngine;
using System.Collections;

public class Prototype_Enemy : MonoBehaviour {

    void FixedUpdate()
    {
        transform.Translate(Vector3.back * Prototype_Stage.Speed * .1f, Space.World);
    }

    void Update()
    {
        if (transform.position.z < -1f)
            Prototype_MobGenerator.Destroy(this.gameObject);
    }

}
