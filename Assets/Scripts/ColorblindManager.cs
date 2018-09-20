using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColorblindManager : MonoBehaviour 
{

	private static ColorblindManager instance = null;

	public Color darkBG;
	public Color lightBG;
	public Color darkBorder;
	public Color lightBorder;
	public Color highlight;
	public Material skyboxCB;

	// Use this for initialization
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
	void Update () 
	{
		
	}

	private void OnLevelWasLoaded()
	{
		if (GameInformation.ColorblindMode)
		{
			GameObject[] lightBorderObj = GameObject.FindGameObjectsWithTag("LightBorder");
			for (int i = 0; i < lightBorderObj.Length; i++) 
			{
				lightBorderObj[i].GetComponent<Image>().color = lightBorder;
			}

			GameObject[] lightBGObj = GameObject.FindGameObjectsWithTag("LightBG");
			for (int i = 0; i < lightBGObj.Length; i++) 
			{
				if (lightBGObj[i].GetComponent<Button>() != null)
				{
					ColorBlock buttonColors = lightBGObj[i].GetComponent<Button>().colors;
					buttonColors.normalColor = lightBG;
					lightBGObj[i].GetComponent<Button>().colors = buttonColors;
				} else if (lightBGObj[i].GetComponent<Image>() != null)
				{
					lightBGObj[i].GetComponent<Image>().color = lightBG;
				}
			}
		}
	}
}
