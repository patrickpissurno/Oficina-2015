using UnityEngine;
using System.Collections;

public class Prototype_PlayerController : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        Prototype_Enemy enemy = col.GetComponent<Prototype_Enemy>();
        if (enemy != null)
        {
            Application.LoadLevel(0);
        }
    }

}
