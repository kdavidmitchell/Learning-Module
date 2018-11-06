using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* IntroScreen.cs

This class defines and manages what the introductory screens display when the player first starts the experience. */

public class IntroScreen : MonoBehaviour 
{

	private Text headerText;
	private Text bodyText1;
	private Text bodyText2;
	private Text bodyText3;
	private List<Text> bodyTexts = new List<Text>();

	private Image bodyIcon1;
	private Image bodyIcon2;
	private Image bodyIcon3;
	private List<Image> bodyIcons = new List<Image>();

	private GameObject nextButton;

	private int headerSize;
	private int bodySize;

	private float textDelay = 2f;
	private int listIndex = 0;
	private float buttonDelay = 6f;

	// Use this for initialization
	void Start () 
	{
		for (int i = 1; i < 4; i++) 
		{
			if (i == 1) 
			{
				bodyText1 = GameObject.Find("BodyText" + i).GetComponent<Text>();
				bodyIcon1 = GameObject.Find("BodyIcon" + i).GetComponent<Image>();
				bodyTexts.Add(bodyText1);
				bodyIcons.Add(bodyIcon1);
			} if (i == 2) 
			{
				bodyText2 = GameObject.Find("BodyText" + i).GetComponent<Text>();
				bodyIcon2 = GameObject.Find("BodyIcon" + i).GetComponent<Image>();
				bodyTexts.Add(bodyText2);
				bodyIcons.Add(bodyIcon2);
			} if (i == 3) 
			{
				bodyText3 = GameObject.Find("BodyText" + i).GetComponent<Text>();
				bodyIcon3 = GameObject.Find("BodyIcon" + i).GetComponent<Image>();
				bodyTexts.Add(bodyText3);
				bodyIcons.Add(bodyIcon3);
			}
		}

		headerText = GameObject.Find("HeaderText").GetComponent<Text>();
		nextButton = GameObject.Find("ButtonBorder");

		headerSize = headerText.fontSize;
		bodySize = bodyText1.fontSize;

		foreach (Text body in bodyTexts)
		{
			SetTextToZeroAlpha(body);
		}

		foreach (Image body in bodyIcons)
		{
			SetIconsToZeroAlpha(body);
		}

		nextButton.SetActive(false);		

	}
	
	// Update is called once per frame
	void Update () 
	{
		textDelay -= Time.deltaTime;
		buttonDelay -= Time.deltaTime;

		if (textDelay <= 0f && listIndex < 3)
		{
			StartCoroutine(FadeTextAndIconsToFullAlpha(1f, bodyTexts[listIndex], bodyIcons[listIndex]));
			listIndex++;
			textDelay = 2f;
		}

		if (buttonDelay <= 0)
		{
			nextButton.SetActive(true);
		}
	}

	private IEnumerator FadeTextAndIconsToFullAlpha(float t, Text i, Image j)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        j.color = new Color(j.color.r, j.color.g, j.color.b, 0);
        while (i.color.a < 1.0f && j.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            j.color = new Color(j.color.r, j.color.g, j.color.b, j.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    private void SetTextToZeroAlpha(Text i)
    {
    	i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
    }

    private void SetIconsToZeroAlpha(Image j)
    {
    	j.color = new Color(j.color.r, j.color.g, j.color.b, 0);
    }
}
