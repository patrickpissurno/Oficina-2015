using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class UI_GameWin : MonoBehaviour {
    public const bool NOTANDROID = true;
    private RawImage rawImage;

    #if NOTANDROID == true
        public MovieTexture video;
        private AudioSource audioSource;

        void Start()
        {
            this.rawImage = this.GetComponent<RawImage>();
            this.audioSource = this.GetComponent<AudioSource>();
            this.audioSource.clip = this.video.audioClip;
            this.video.Play();
            this.audioSource.Play();
        }
    #endif
    #if NOTANDROID == false
        void Start()
        {
            this.rawImage = this.GetComponent<RawImage>();
            this.rawImage.color = Color.black;
            this.rawImage.gameObject.SetActive(false);
            Handheld.PlayFullScreenMovie("Cutscene_Win.mp4", Color.black, FullScreenMovieControlMode.Hidden, FullScreenMovieScalingMode.Fill);
            Application.LoadLevel("MainMenu");
        }
    #endif
}
