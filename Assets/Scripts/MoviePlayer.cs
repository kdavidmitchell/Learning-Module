﻿using System.Collections;
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
		can.gameObject.SetActive(false);
	}

	public void PlayMovie()
	{
		player.url = System.IO.Path.Combine(Application.streamingAssetsPath, "trimmed_visual_system.mp4");
		player.SetTargetAudioSource(0, audioSource);
		player.loopPointReached += EndReached;
		player.Prepare();
		player.Play();
	}

	void EndReached(VideoPlayer player)
	{
		mainCam.gameObject.SetActive(true);
		videoCam.gameObject.SetActive(false);
		can.gameObject.SetActive(true);
	}
}
