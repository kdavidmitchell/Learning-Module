using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	private bool readingDone = false;
	private bool interventionDone = false;
	private bool differencesDone = false;
	private bool wrongDone = false;

	// Use this for initialization
	void Start () 
	{
		selectedTopicTitle.SetActive(false);
		readingBodyText.SetActive(false);
		interventionBodyText.SetActive(false);
		differencesBodyText.SetActive(false);
		wrongBodyText.SetActive(false);
		topicReturnButton.SetActive(false);
		areaReturnButton.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void HideHelpButton()
	{
		helpText.SetActive(false);
	}

	public void ReturnToTopicSelect()
	{
		selectedTopicTitle.SetActive(false);
		readingBodyText.SetActive(false);
		interventionBodyText.SetActive(false);
		differencesBodyText.SetActive(false);
		wrongBodyText.SetActive(false);

		readingButton.SetActive(true);
		interventionButton.SetActive(true);
		differencesButton.SetActive(true);
		wrongButton.SetActive(true);

		topicReturnButton.SetActive(false);
	}

	public void ReadingClicked()
	{
		interventionButton.SetActive(false);
		differencesButton.SetActive(false);
		wrongButton.SetActive(false);

		selectedTopicTitle.SetActive(true);
		Text topicTitleText = selectedTopicTitle.GetComponentInChildren<Text>();
		topicTitleText.text = "Role in reading";

		readingBodyText.SetActive(true);

		topicReturnButton.SetActive(true);
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
		if (readingDone && interventionDone && differencesDone && wrongDone)
		{
			areaReturnButton.SetActive(true);
			GameInformation.TPJComplete = true;
			SaveInformation.SaveAllInformation();
		}
	}

	
}
