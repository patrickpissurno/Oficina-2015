using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RotaSettings : MonoBehaviour
{
    public Rota.Level[] Levels;
    
}

public static class Rota {
    public static string[] character_names = { "Douglas Wilson", "Garota" };

    public static void Initialize()
    {
        Characters = GetCharacters();
    }

    #region Gets
    private static Character[] Characters;
    //private static Level[] Levels;
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
    //public static Level[] GetLevels()
    //{
    //    if (Levels != null)
    //        return Levels;
    //    else
    //    {
    //        Levels = new Level[character_names.Length];
    //        for (int i = 0; i < character_names.Length; i++)
    //        {
    //            Characters[i] = new Character();
    //            Characters[i].Name = character_names[i];
    //            Characters[i].Walk_Left = Resources.LoadAll<Sprite>("Characters/" + i + "/Walk/Left");
    //            Characters[i].Walk_Center = Resources.LoadAll<Sprite>("Characters/" + i + "/Walk/Center");
    //            Characters[i].Walk_Right = Resources.LoadAll<Sprite>("Characters/" + i + "/Walk/Right");
    //            Characters[i].Jump_Left = Resources.LoadAll<Sprite>("Characters/" + i + "/Jump/Left");
    //            Characters[i].Jump_Center = Resources.LoadAll<Sprite>("Characters/" + i + "/Jump/Center");
    //            Characters[i].Jump_Right = Resources.LoadAll<Sprite>("Characters/" + i + "/Jump/Right");
    //        }
    //        return Levels;
    //    }
    //}
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
        public float Timer;
    }
}

