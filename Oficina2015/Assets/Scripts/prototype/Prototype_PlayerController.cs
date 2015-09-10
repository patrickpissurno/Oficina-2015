using UnityEngine;
using System.Collections;

public class Prototype_PlayerController : MonoBehaviour {

    void Start()
    {
        transform.localScale *= .18f;
        transform.position += Vector3.up * .1f;
    }

    void OnTriggerEnter(Collider col)
    {
        Prototype_Enemy enemy = col.GetComponent<Prototype_Enemy>();
        if (enemy != null)
        {
            Prototype_MainGame.instance.Loose();
        }
    }

}
