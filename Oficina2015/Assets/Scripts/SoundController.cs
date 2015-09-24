using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour {

    public static SoundController instance;
    private AudioSource audioSource;

    private AudioClip fx_click;
    private AudioClip fx_loose;
    private AudioClip fx_win;
    private AudioClip fx_damage;
    private AudioClip bg_main;
    private AudioClip fx_cutscene1;

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

    void Update()
    {
        if (!Prototype_MainGame.SoundEnabled && this.audioSource.isPlaying)
            this.audioSource.Stop();
        else if (Prototype_MainGame.SoundEnabled && !this.audioSource.isPlaying)
            this.audioSource.Play();

    }

    private void Reload()
    {
        this.fx_click = Resources.Load<AudioClip>("Sounds/click");
        this.fx_loose = Resources.Load<AudioClip>("Sounds/loose");
        this.fx_win = Resources.Load<AudioClip>("Sounds/win");
        this.fx_damage = Resources.Load<AudioClip>("Sounds/damage");
        this.bg_main = Resources.Load<AudioClip>("Sounds/bg_main");
        this.fx_cutscene1 = Resources.Load<AudioClip>("Sounds/cutscene1");
    }

    public void PlayFX(string audio)
    {
        if (Prototype_MainGame.SoundEnabled)
        {
            AudioClip clip = null;
            switch (audio)
            {
                case "click":
                    clip = this.fx_click;
                    break;
                case "loose":
                    clip = this.fx_loose;
                    break;
                case "win":
                    clip = this.fx_win;
                    break;
                case "damage":
                    clip = this.fx_damage;
                    break;
                case "cutscene1":
                    clip = this.fx_cutscene1;
                    break;
            }
            if (clip != null)
                this.audioSource.PlayOneShot(clip);
        }
    }

    public static void _PlayFX(string audio)
    {
        instance.PlayFX(audio);
    }

    public static void _PlayBG(string audio)
    {
        instance.PlayBG(audio);
    }

    public void PlayBG(string audio)
    {
        if (Prototype_MainGame.SoundEnabled)
        {
            AudioClip clip = null;
            switch (audio)
            {
                case "main":
                    clip = this.bg_main;
                    break;
                case "none":
                    this.audioSource.clip = null;
                    this.audioSource.Stop();
                    break;
            }
            if (clip != null && clip != this.audioSource.clip)
            {
                this.audioSource.Stop();
                this.audioSource.clip = clip;
                this.audioSource.loop = true;
                this.audioSource.Play();
            }
        }
    }

}
