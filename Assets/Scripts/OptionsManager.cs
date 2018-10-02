using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour 
{

	public GameObject changesButton;
	public Toggle colorblindModeToggle; 

	// Use this for initialization
	void Start () 
	{
		//changesButton.SetActive(false);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ApplyChanges()
	{
		if (colorblindModeToggle.isOn)
		{
			GameInformation.ColorblindMode = true;
			SaveInformation.SaveAllInformation();
		} else 
		{
			GameInformation.ColorblindMode = false;
			SaveInformation.SaveAllInformation();	
		}
	}
}
