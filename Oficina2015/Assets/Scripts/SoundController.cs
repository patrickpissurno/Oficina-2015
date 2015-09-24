using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour {

    public static SoundController instance;
    private AudioSource audioSource;

    private AudioClip fx_click;
    private AudioClip fx_loose;
    private AudioClip bg_main;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        this.audioSource = this.GetComponent<AudioSource>();
        this.Reload();
    }

    private void Reload()
    {
        this.fx_click = Resources.Load<AudioClip>("Sounds/click");
        this.fx_loose = Resources.Load<AudioClip>("Sounds/loose");
        this.bg_main = Resources.Load<AudioClip>("Sounds/bg_main");
    }

    public static void PlayFX(string audio)
    {
        AudioClip clip = null;
        switch (audio)
        {
            case "click":
                clip = instance.fx_click;
                break;
            case "loose":
                clip = instance.fx_loose;
                break;
        }
        if(clip != null)
            instance.audioSource.PlayOneShot(clip);
    }

    public static void PlayBG(string audio)
    {
        AudioClip clip = null;
        switch (audio)
        {
            case "main":
                clip = instance.bg_main;
                break;
        }
        if (clip != null)
        {
            instance.audioSource.Stop();
            instance.audioSource.clip = clip;
            instance.audioSource.loop = true;
            instance.audioSource.Play();
        }
    }

}
