using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using RenderHeads.Media.AVProVideo;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour {
	const string BASE_URL = "https://storage.googleapis.com/vrnd-360-media.appspot.com/";
	string[] video_files = {"Iguazu001.mp4", "Iguazu002.mp4"};
	public Sprite[] sprites;
	private int current_video_id = 0;

	private MediaPlayer mediaPlayer;
	public GameObject mediaPlayerObj;

	public GameObject playButton;
	public GameObject pauseButton;
	public GameObject moveButton;
	public GameObject particle;
	public GameObject moveImage;

	public AudioSource seMove;
	public AudioSource sePlayPause;

	// Use this for initialization
	void Start () {
		current_video_id = MoveScene.initial_video_id;

		mediaPlayer = mediaPlayerObj.GetComponent<MediaPlayer> ();
		mediaPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.AbsolutePathOrURL,BASE_URL + video_files[current_video_id]);
		moveImage.GetComponent<Image> ().sprite = sprites [current_video_id];
	}


	// Update is called once per frame
	void Update () {
		if (mediaPlayer.Control.IsFinished ()) {
			SceneManager.LoadScene ("End");
		}
	}

	public void PlayVideo () {
		sePlayPause.Play ();
		mediaPlayer.Play ();
		playButton.SetActive (false);
		pauseButton.SetActive (true);
		moveButton.SetActive (false);
		ToggleParticle ();
	}

	public void PauseVideo () {
		sePlayPause.Play ();
		mediaPlayer.Pause ();
		playButton.SetActive (true);
		pauseButton.SetActive (false);
		moveButton.SetActive (true);
		ToggleParticle ();
	}

	public void MoveVideo () {
		seMove.Play ();
		current_video_id = Mathf.Abs (current_video_id - 1);
		mediaPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.AbsolutePathOrURL,BASE_URL + video_files[current_video_id], true);
		moveImage.GetComponent<Image> ().sprite = sprites [current_video_id];
		playButton.SetActive (false);
		pauseButton.SetActive (true);
		moveButton.SetActive (false);
	}

	public void ToggleParticle () {
		if (particle.activeInHierarchy) {
			particle.SetActive (false);
		} else {
			particle.SetActive (true);
		}
	}

}
