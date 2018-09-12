using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSelectionManager : MonoBehaviour 
{

	public GameObject posttestButton;
	public GameObject help1;
	public GameObject help2;

	// Use this for initialization
	void Start () 
	{
		LoadInformation.LoadAllInformation();
		posttestButton.SetActive(false);

		CheckIfAllAreasAreComplete();

		if (GameInformation.AllAreasComplete)
		{
			EnablePosttest();
		}	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	private void CheckIfAllAreasAreComplete()
	{
		if (GameInformation.TPJComplete)
		{
			GameInformation.AllAreasComplete = true;
			SaveInformation.SaveAllInformation();
		}
	}

	private void EnablePosttest()
	{
		posttestButton.SetActive(true);
		help1.SetActive(false);
		help2.SetActive(false);
	}
}
