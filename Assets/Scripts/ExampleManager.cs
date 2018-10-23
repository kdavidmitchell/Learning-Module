using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleManager : MonoBehaviour 
{

	public GameObject currentBodyText;
	public GameObject exampleSpace;

	public static bool exampleIsActive = false;

	// Use this for initialization
	void Start () 
	{
		exampleSpace.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void HideObjects()
	{
		currentBodyText.SetActive(false);
	}

	public void EnableExampleSpace()
	{
		exampleIsActive = true;
		exampleSpace.SetActive(true);
	}
}
