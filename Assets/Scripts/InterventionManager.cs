using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterventionManager : MonoBehaviour 
{

	private int index = 0;
	private GameObject activeText;
	
	public GameObject[] texts = new GameObject[5];
	public GameObject forward;
	public GameObject backward;
	public GameObject nextSceneButton;

	public GameObject topicSelectSpeechButton;
	public SpeechButton sb;

	public AudioClip[] clips = new AudioClip[5];

	// Use this for initialization
	void Start () 
	{
		GameInformation.InterventionComplete = true;
		SaveInformation.SaveAllInformation();

		activeText = texts[index];
		for (int i = 1; i < 5; i++) 
		{
			texts[i].SetActive(false);
		}

		nextSceneButton.SetActive(false);

		sb = topicSelectSpeechButton.GetComponentInChildren<SpeechButton>();
	}

	void Update()
	{
		if (index == 4)
		{
			forward.SetActive(false);
			nextSceneButton.SetActive(true);
		} else if (index != 4)
		{
			forward.SetActive(true);
		}

		if (index == 0)
		{
			backward.SetActive(false);
		} else if (index != 0)
		{
			backward.SetActive(true);
		}
	}

	public void IncreaseIndexAndDisplay()
	{
		if (index < 4)
		{
			activeText.SetActive(false);
			index++;
			activeText = texts[index];
			activeText.SetActive(true);

			SwitchAudioClip();
		}
	}

	public void DecreaseIndexAndDisplay()
	{
		if (index > 0)
		{
			activeText.SetActive(false);
			index--;
			activeText = texts[index];
			activeText.SetActive(true);

			SwitchAudioClip();
		}
	}

	public void SwitchAudioClip()
	{
		sb.speechClip = clips[index];
	}
}
