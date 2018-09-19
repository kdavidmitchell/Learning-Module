using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorblindManager : MonoBehaviour 
{

	private static ColorblindManager instance = null;

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
	void Update () {
		
	}
}
