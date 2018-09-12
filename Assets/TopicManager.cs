using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopicManager : MonoBehaviour 
{

	private GameObject helpText;
	private GameObject readingButton;
	private GameObject interventionButton;
	private GameObject differencesButton;
	private GameObject wrongButton;

	private bool readingDone = false;
	private bool interventionDone = false;
	private bool differencesDone = false;
	private bool wrongDone = false;

	// Use this for initialization
	void Start () 
	{
		helpText = GameObject.Find("HelpText");
		readingButton = GameObject.Find("Reading");
		interventionButton = GameObject.Find("Intervention");
		differencesButton = GameObject.Find("Differences");
		wrongButton = GameObject.Find("Wrong");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
}
