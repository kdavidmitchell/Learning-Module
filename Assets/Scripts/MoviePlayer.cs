using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class MoviePlayer : MonoBehaviour 
{

	public Camera mainCam;
	public Camera videoCam;
	public VideoPlayer player;
	public Canvas can;
	public AudioSource audioSource;
	public AudioClip clip;

	public string videoName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SwitchCameras()
	{
		mainCam.gameObject.SetActive(false);
		videoCam.gameObject.SetActive(true);
		videoCam.gameObject.GetComponent<AudioSource>().clip = clip;
		can.gameObject.SetActive(false);
	}

	public void PlayMovie()
	{
		SetActivePlayer();
		player.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoName);
		player.SetTargetAudioSource(0, audioSource);
		player.loopPointReached += EndReached;
		player.Prepare();
		player.Play();
	}

	void EndReached(VideoPlayer player)
	{
		player.Stop();
		mainCam.gameObject.SetActive(true);
		videoCam.gameObject.SetActive(false);
		can.gameObject.SetActive(true);
		VideoController.videoIsPlaying = false;
	}

	public void SetActivePlayer()
	{
		VideoController.activePlayer = player;
		VideoController.activeMoviePlayer = this;
		VideoController.videoIsPlaying = true;
	}

	public void EndPlaybackAndReturn()
	{
		player.Stop();
		mainCam.gameObject.SetActive(true);
		videoCam.gameObject.SetActive(false);
		can.gameObject.SetActive(true);
		VideoController.videoIsPlaying = false;
	}
}
