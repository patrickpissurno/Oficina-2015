using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fade : MonoBehaviour {
    public static Fade instance = null;
    private bool InProgress = false;

    public delegate void Callback();

    private Image fadeI;
    private string nextLevel = "";

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
            Destroy(gameObject);
    }

    void Start()
    {
        
    }

    void OnLevelWasLoaded()
    {
        if (Application.loadedLevelName == nextLevel)
        {
            nextLevel = "";
            FadeOut(instance.GetImage(), () => { });
        }
    }

    public Image GetImage()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if(canvas == null)
            return null;
        Transform f = canvas.transform.Find("_Fade");
		GameObject o = null;
        if (canvas.transform.Find("_Fade") == null)
        {
            f = new GameObject("_Fade").transform;
			o = f.gameObject;
            f.transform.SetParent(canvas.transform, false);
            RectTransform r = o.AddComponent<RectTransform>();
            Image i = o.AddComponent<Image>();
            Texture2D t = new Texture2D(1, 1);
            t.SetPixel(0, 0, Color.black);
            t.Apply();
            i.sprite = Sprite.Create(t, new Rect(new Vector2(0,0), new Vector2(1,1)), Vector2.zero);
            r.anchorMin = new Vector2(0, 0);
            r.anchorMax = new Vector2(1, 1);
        }
        if (o != null)
            return o.GetComponent<Image>();
        else
            return null;
    }

    public static void FadeIn(Image i, Callback c)
    {
        if (!instance.InProgress)
        {
            instance.InProgress = true;
            instance.StartCoroutine(instance.fadeIn(i, c));
        }
    }

    public static void FadeOut(Image i, Callback c)
    {
        if (!instance.InProgress)
        {
            instance.InProgress = true;
            instance.StartCoroutine(instance.fadeOut(i, c));
        }
    }

    public static void LoadLevel(string name)
    {
        instance.nextLevel = name;
        Image i = instance.GetImage();
        i.color = new Color(0, 0, 0, 0);
        FadeIn(i, () =>
        {
            Application.LoadLevel(name);
        });
    }

    IEnumerator fadeIn(Image i, Callback c)
    {
        for (float alpha = 0; alpha <= 1; alpha += .1f)
        {
            yield return new WaitForSeconds(0.01f);
            i.color = new Color(i.color.r, i.color.g, i.color.b, alpha > 1 ? 1 : alpha);
        }
        InProgress = false;
        c();
    }

    IEnumerator fadeOut(Image i, Callback c)
    {
        for (float alpha = 1; alpha >= 0; alpha -= .1f)
        {
            yield return new WaitForSeconds(0.01f);
            i.color = new Color(i.color.r, i.color.g, i.color.b, alpha < 0 ? 0 : alpha);
        }
        InProgress = false;
        Destroy(i.gameObject);
        c();
    }

    public IEnumerator DelayedCallback(Callback c, float timer)
    {
        yield return new WaitForSeconds(timer);
        c();
    }
}
