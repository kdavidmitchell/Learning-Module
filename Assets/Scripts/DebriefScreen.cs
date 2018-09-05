using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebriefScreen : MonoBehaviour 
{

	private List<GameObject> screenContent = new List<GameObject>();

	private int contentIndex = 0;
	private float contentDelay = 3f;

	// Use this for initialization
	void Start () 
	{
		screenContent.Add(GameObject.Find("BodyBorder3"));
		screenContent.Add(GameObject.Find("BodyBorder2"));
		screenContent.Add(GameObject.Find("BodyBorder1"));

		foreach (GameObject content in screenContent)
		{
			content.SetActive(false);
		}

		screenContent[0].SetActive(true);
		contentIndex++;
	}
	
	// Update is called once per frame
	void Update () 
	{
		contentDelay -= Time.deltaTime;
		if (contentDelay <= 0 && contentIndex < 3)
		{
			screenContent[contentIndex].SetActive(true);
			contentIndex++;
			contentDelay = 3f;
		}
	}
}
