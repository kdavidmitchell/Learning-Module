using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
	private static VideoController instance = null;

	public static VideoPlayer activePlayer;
    public static MoviePlayer activeMoviePlayer;
	public static bool videoIsPlaying = false;

	private GameObject activeCamera;
	private GameObject mainCamera;
	private GameObject canvas;

    void Awake() 
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		} else 
		{
			Destroy(gameObject);	
		}
	}

    // Update is called once per frame
    void Update()
    {
        if (videoIsPlaying)
        {
        	if (Input.GetKeyDown(KeyCode.Space))
        	{
        		activePlayer.Pause();
        		videoIsPlaying = false;
        	}
        } else if (!videoIsPlaying)
        {
        	if (Input.GetKeyDown(KeyCode.Space))
        	{
        		activePlayer.Play();
        		videoIsPlaying = true;
        	}
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            activeMoviePlayer.EndPlaybackAndReturn();
        }
    }

    // public GameObject FindActiveCamera()
    // {
    // 	GameObject[] cameras = GameObject.FindGameObjectsWithTag("Camera");
    // 	for (int i = 0; i < cameras.Length; i++) 
    // 	{
    // 		if (cameras[i].activeInHierarchy)
    // 		{
    // 			activeCamera = cameras[i];
    // 			return activeCamera;
    // 		}
    // 	}

    // 	return null;
    // }

    // public GameObject FindMainCamera()
    // {
    // 	mainCamera = GameObject.Find("Main Camera");
    // 	return mainCamera;
    // }

    // public GameObject FindCanvas()
    // {
    // 	canvas = GameObject.Find("Canvas");
    // 	return canvas;
    // }
}
