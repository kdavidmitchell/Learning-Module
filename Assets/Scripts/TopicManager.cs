using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopicManager : MonoBehaviour 
{

	public GameObject helpText;
	public GameObject readingButton;
	public GameObject interventionButton;
	public GameObject differencesButton;
	public GameObject wrongButton;
	public GameObject selectedTopicTitle;
	public GameObject readingBodyText;
	public GameObject interventionBodyText;
	public GameObject differencesBodyText;
	public GameObject wrongBodyText;
	public GameObject topicReturnButton;
	public GameObject areaReturnButton;

	public GameObject topicSelectSpeechButton;
	public GameObject readingSpeechButton;

	private GameObject[] topicButtons = new GameObject[4];
	private GameObject[] topicTexts = new GameObject[4];
	private bool readingDone = false;
	private bool interventionDone = false;
	private bool differencesDone = false;
	private bool wrongDone = false;

	// Use this for initialization
	void Start () 
	{	
		topicButtons[0] = readingButton;
		topicButtons[1] = interventionButton;
		topicButtons[2] = differencesButton;
		topicButtons[3] = wrongButton;

		topicTexts[0] = readingBodyText;
		topicTexts[1] = interventionBodyText;
		topicTexts[2] = differencesBodyText;
		topicTexts[3] = wrongBodyText;

		for (int i = 0; i < topicTexts.Length; i++) 
		{
			if (topicTexts[i] != null)
			{
				topicTexts[i].SetActive(false);
			}
		}

		for (int i = 1; i < topicButtons.Length; i++) 
		{
			if (topicButtons[i] != null)
			{
				topicButtons[i].SetActive(false);
			}
		}
		
		selectedTopicTitle.SetActive(false);
		topicReturnButton.SetActive(false);
		areaReturnButton.SetActive(false);
		readingSpeechButton.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void HideHelpButton()
	{
		helpText.SetActive(false);
	}

	public void ShowFullBrainReturnButton()
	{
		areaReturnButton.SetActive(true);
	}

	public void ReturnToTopicSelect()
	{
		readingSpeechButton.SetActive(false);
		selectedTopicTitle.SetActive(false);
		topicReturnButton.SetActive(false);
		
		for (int i = 0; i < topicTexts.Length; i++) 
		{
			if (topicTexts[i] != null)
			{
				topicTexts[i].SetActive(false);
			}
		}

		if (readingDone)
		{
			topicButtons[0].SetActive(true);
			topicButtons[3].SetActive(true);
		}

		if (readingDone && wrongDone)
		{
			topicButtons[0].SetActive(true);
			topicButtons[3].SetActive(true);
			topicButtons[2].SetActive(true);
		}
		
		topicSelectSpeechButton.SetActive(true);
	}

	public void ReadingClicked()
	{
		for (int i = 0; i < topicButtons.Length; i++) 
		{
			if (topicButtons[i] != null && i != 0)
			{
				topicButtons[i].SetActive(false);
			}
		}
		
		topicSelectSpeechButton.SetActive(false);

		selectedTopicTitle.SetActive(true);
		Text topicTitleText = selectedTopicTitle.GetComponentInChildren<Text>();
		topicTitleText.text = "Role in reading";

		if (readingBodyText != null)
		{
			readingBodyText.SetActive(true);
		}

		topicReturnButton.SetActive(true);
		readingSpeechButton.SetActive(true);
		readingButton.SetActive(false);

		readingDone = true;
	}

	public void InterventionClicked()
	{
		readingButton.SetActive(false);
		differencesButton.SetActive(false);
		wrongButton.SetActive(false);

		selectedTopicTitle.SetActive(true);
		Text topicTitleText = selectedTopicTitle.GetComponentInChildren<Text>();
		topicTitleText.text = "Intervention";

		interventionBodyText.SetActive(true);

		topicReturnButton.SetActive(true);
		interventionButton.SetActive(false);

		interventionDone = true;
	}

	public void DifferencesClicked()
	{
		interventionButton.SetActive(false);
		readingButton.SetActive(false);
		wrongButton.SetActive(false);

		selectedTopicTitle.SetActive(true);
		Text topicTitleText = selectedTopicTitle.GetComponentInChildren<Text>();
		topicTitleText.text = "Differences between typical readers and those with dyslexia";

		differencesBodyText.SetActive(true);

		topicReturnButton.SetActive(true);
		differencesButton.SetActive(false);

		differencesDone = true;
	}

	public void WrongClicked()
	{
		interventionButton.SetActive(false);
		differencesButton.SetActive(false);
		readingButton.SetActive(false);

		selectedTopicTitle.SetActive(true);
		Text topicTitleText = selectedTopicTitle.GetComponentInChildren<Text>();
		topicTitleText.text = "When things go wrong";

		wrongBodyText.SetActive(true);

		topicReturnButton.SetActive(true);
		wrongButton.SetActive(false);

		wrongDone = true;
	}

	public void CheckIfAllTopicsAreDone()
	{
		if (readingDone && differencesDone && wrongDone)
		{
			areaReturnButton.SetActive(true);

			Scene currentScene = SceneManager.GetActiveScene();
			int buildIndex = currentScene.buildIndex;
			if (buildIndex == 8)
			{
				GameInformation.TPJComplete = true;
			} else if (buildIndex == 15)
			{
				GameInformation.OTComplete = true;
			} else if (buildIndex == 16)
			{
				GameInformation.RHComplete = true;
			}
			
			SaveInformation.SaveAllInformation();
		}
	}

	
}
