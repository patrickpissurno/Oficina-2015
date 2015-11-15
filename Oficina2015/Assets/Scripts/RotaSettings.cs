using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RotaSettings : MonoBehaviour
{
    public Rota.Level[] Levels;
    void Awake()
    {
        if (Rota.instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            Rota.instance = this;
            for (int i = 0; i < Levels.Length; i++)
            {
                Levels[i].Id = i;
                if (PlayerPrefs.HasKey("Stars_" + i))
                    Levels[i].Stars = PlayerPrefs.GetInt("Stars_" + i);
            }
        }
        else
            Destroy(gameObject);
    }
    void Start()
    {
        if(PlayerPrefs.HasKey("LevelUnlock"))
            Rota.LevelUnlock = PlayerPrefs.GetInt("LevelUnlock");
    }
}

public static class Rota {
    public static RotaSettings instance = null;
    public static string[] character_names = { "Douglas Wilson", "Garota" };
    public static int LevelUnlock = 0;

    public static void Initialize()
    {
        Characters = GetCharacters();
    }

    #region Gets
    private static Character[] Characters;
    public static Character[] GetCharacters()
    {
        if (Characters != null)
            return Characters;
        else
        {
            Characters = new Character[character_names.Length];
            for (int i = 0; i < character_names.Length; i++)
            {
                Characters[i] = new Character();
                Characters[i].Name = character_names[i];
                Characters[i].Walk_Left = Resources.LoadAll<Sprite>("Characters/" + i + "/Walk/Left");
                Characters[i].Walk_Center = Resources.LoadAll<Sprite>("Characters/" + i + "/Walk/Center");
                Characters[i].Walk_Right = Resources.LoadAll<Sprite>("Characters/" + i + "/Walk/Right");
                Characters[i].Jump_Left = Resources.LoadAll<Sprite>("Characters/" + i + "/Jump/Left");
                Characters[i].Jump_Center = Resources.LoadAll<Sprite>("Characters/" + i + "/Jump/Center");
                Characters[i].Jump_Right = Resources.LoadAll<Sprite>("Characters/" + i + "/Jump/Right");
            }
            return Characters;
        }
    }
    #endregion

    public class Character
    {
        public string Name { get; set; }
        public Sprite[] Walk_Left { get; set; }
        public Sprite[] Walk_Center { get; set; }
        public Sprite[] Walk_Right { get; set; }
        public Sprite[] Jump_Left { get; set; }
        public Sprite[] Jump_Center { get; set; }
        public Sprite[] Jump_Right { get; set; }
    }

    [System.Serializable]
    public class Level
    {
        public string Name;
        public int Distance;
        public int Timer;
        public int TargetTimer;
        public float Speed;
        [HideInInspector]
        public int Id;
        [HideInInspector]
        public int Stars = 0;
    }
}

