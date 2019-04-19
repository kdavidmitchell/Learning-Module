using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour 
{

	public GameObject changesButton;
	public Toggle colorblindModeToggle;
	public Toggle speechAutoPlayToggle;

	private ColorblindManager cbm; 

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ApplyChanges()
	{

		if (speechAutoPlayToggle.isOn)
		{
			GameInformation.SpeechAutoPlay = true;
			SaveInformation.SaveAllInformation();
			Debug.Log(GameInformation.SpeechAutoPlay);
		} else 
		{
			GameInformation.SpeechAutoPlay = false;
			SaveInformation.SaveAllInformation();
		}

		if (colorblindModeToggle.isOn)
		{
			GameInformation.ColorblindMode = true;
			SaveInformation.SaveAllInformation();
			cbm = GameObject.Find("ColorblindManager").GetComponent<ColorblindManager>();
			cbm.UpdateColorScheme();
		} else 
		{
			GameInformation.ColorblindMode = false;
			SaveInformation.SaveAllInformation();
			SceneManager.LoadScene(14);
			Debug.Log(GameInformation.SpeechAutoPlay);	
		}
	}
}
