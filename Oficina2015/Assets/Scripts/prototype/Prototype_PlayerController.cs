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
            switch (enemy.collisionAction)
            {
                case Prototype_Enemy.CollisionAction.Death:
                    Prototype_MainGame.instance.Loose();
                    break;
                case Prototype_Enemy.CollisionAction.Slow:
                    Prototype_MainGame.instance.SetSlow();
                    break;
                case Prototype_Enemy.CollisionAction.Speed:
                    Prototype_MainGame.instance.SetSpeed();
                    break;
            }
        }
    }

}
