using UnityEngine;
using System.Collections;

public class Prototype_Enemy : MonoBehaviour {

    public float Speed = 0f;

    void FixedUpdate()
    {
        transform.Translate(Vector3.back * (Prototype_Stage.BaseSpeed + Speed) * .1f, Space.World);
    }

    void Update()
    {
        if (transform.position.z < -1f)
            Prototype_MobGenerator.Destroy(this.gameObject);
    }

}
