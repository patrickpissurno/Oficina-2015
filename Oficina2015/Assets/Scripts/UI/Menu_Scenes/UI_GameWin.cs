//#define NOTANDROID

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(AudioSource))]
public class UI_GameWin : MonoBehaviour {
    private RawImage rawImage;

    #if NOTANDROID
        private AudioSource audioSource;
        public MovieTexture movie;
        void Start()
        {
            Invoke("MoviePlay", 1f);
        }

        void MoviePlay()
        {
            this.rawImage = this.GetComponent<RawImage>();
            this.rawImage.texture = movie;
            this.audioSource = this.GetComponent<AudioSource>();
            this.audioSource.clip = movie.audioClip;
            this.audioSource.Play();
            movie.Play();
        }
    #else
        void Start()
        {
            this.rawImage = this.GetComponent<RawImage>();
            this.rawImage.color = Color.black;
            this.rawImage.gameObject.SetActive(false);
            Invoke("MoviePlay", .5f);
        }

        void MoviePlay()
        {
            Handheld.PlayFullScreenMovie("Cutscene_Win.mp4", Color.black, FullScreenMovieControlMode.Hidden, FullScreenMovieScalingMode.Fill);
            Application.LoadLevel("MainMenu");
        }
    #endif
}
