using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class LevelController : MonoBehaviour {

    public static List<LevelController> LevelControllers;

    public int Id = 0;
    public int StarAmount = 0;
    public bool Locked = false;
    private static Sprite[] StarSprites;
    private Image StarImage;
    private Text Title;
    private GameObject LockedObj;
    void Awake()
    {
        if (LevelControllers == null)
            LevelControllers = new List<LevelController>();
        LevelControllers.Add(this);
    }
	public void Start () {
        if (StarSprites == null)
            StarSprites = Resources.LoadAll<Sprite>("UI/StarSprite");
        if(StarImage == null)
            StarImage = transform.Find("Stars").GetComponent<Image>();
        StarImage.sprite = StarSprites[StarAmount];
        if(Title == null)
            Title = transform.Find("Number").GetComponent<Text>();
        Title.text = (Id + 1).ToString();
        if (LockedObj == null)
            LockedObj = transform.Find("Locked").gameObject;
        LockedObj.SetActive(Locked);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
