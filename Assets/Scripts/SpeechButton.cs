using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechButton : MonoBehaviour 
{
	private AudioManager am;
	public AudioClip speechClip;

	// Use this for initialization
	void Start () 
	{
		am = GameObject.Find("AudioManager").GetComponent<AudioManager>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlaySpeechClip()
	{
		am.PlaySingle(speechClip);
	} 
}
