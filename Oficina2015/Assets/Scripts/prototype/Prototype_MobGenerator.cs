using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Prototype_MobGenerator : MonoBehaviour {

    public static Prototype_MobGenerator instance;

    private static GameObject[] Prefabs;
    public static List<GameObject> Pool;

    void Awake()
    {
        if(instance == null)
            instance = this;
    }

	void Start () {
        if(Prefabs == null)
        {
            Prefabs = Resources.LoadAll<GameObject>("Obstacles");
        }

        Pool = new List<GameObject>();
        Transform PoolParent = new GameObject("MobPool").transform;
        foreach (GameObject prefab in Prefabs)
        {
            if (prefab != null)
            {
                for (int i = 0; i < 2; i++)
                {
                    GameObject obj = Instantiate(prefab) as GameObject;
                    obj.transform.SetParent(PoolParent);
                    obj.SetActive(false);
                    Pool.Add(obj);
                }
            }
        }

        StartCoroutine(Spawner());
	}

    private IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f/Prototype_Stage.BaseSpeed);
            switch (Random.Range(0, 3))
            {
                case 0:
                    SpawnRandom(Prototype_MainGame.Side.Left);
                    break;
                case 1:
                    SpawnRandom(Prototype_MainGame.Side.Center);
                    break;
                case 2:
                    SpawnRandom(Prototype_MainGame.Side.Right);
                    break;
            }
        }
    }

    public static void SpawnRandom(Prototype_MainGame.Side Side)
    {
        GameObject obj = Pool[Random.Range(0, Pool.Count)];
        Pool.Remove(obj);

        obj.transform.position = new Vector3((int)Side * 1.3f, obj.transform.position.y, 20f);
        obj.SetActive(true);
    }

    public static void Destroy(GameObject obj)
    {
        Pool.Add(obj);
        obj.SetActive(false);
    }
}
