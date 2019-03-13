using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour 
{

	public AudioSource efxSource;
	public AudioSource musicSource;
	public static AudioManager instance = null;
    public static bool isMute = false;

	public AudioClip[] speechClips = new AudioClip[11];

	void Awake ()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy (gameObject);
        
        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad (gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            efxSource.Stop();
        }
    }

    public void PlaySingle(AudioClip clip)
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        efxSource.clip = clip;
        
        //Play the clip.
        efxSource.Play();
    }
	
	public void SearchAndPlaySpeechClip(int index)
	{
		PlaySingle(speechClips[index]);
	}

    private void OnLevelWasLoaded()
    {
        efxSource.Stop();
        efxSource.mute = false;
        LoadInformation.LoadAllInformation();

        if (GameInformation.SpeechAutoPlay)
        {
            Debug.Log("auto play is on");
            SpeechButton currentSpeechButton = GameObject.Find("SpeechButtonBorder").GetComponentInChildren<SpeechButton>();
            Debug.Log(currentSpeechButton.name);
            currentSpeechButton.PlaySpeechClip();
        }
    }
}
