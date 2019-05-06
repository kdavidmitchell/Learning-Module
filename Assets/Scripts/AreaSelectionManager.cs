using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSelectionManager : MonoBehaviour 
{

	public GameObject interventionButton;
	public GameObject testButton;
	public GameObject help1;
	public GameObject help2;

	public Color completeColor;

	private Renderer areaRenderer;
	private Fade areaFade;

	// Use this for initialization
	void Start () 
	{
		LoadInformation.LoadAllInformation();
		//interventionButton.SetActive(false);
		testButton.SetActive(false);

		CheckIfAllAreasAreComplete();

		if (GameInformation.AllAreasComplete)
		{
			EnableInterventionButton();
		}

		if (GameInformation.InterventionComplete)
		{
			EnableTestButton();
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
			areaRenderer = GameObject.Find("TPJ").GetComponent<Renderer>();
			areaRenderer.material.SetColor("_EmissionColor", completeColor);
			areaFade = GameObject.Find("TPJ").GetComponent<Fade>();
			Destroy(areaFade);
		}

		if (GameInformation.OTComplete)
		{
			areaRenderer = GameObject.Find("OT").GetComponent<Renderer>();
			areaRenderer.material.SetColor("_EmissionColor", completeColor);
			areaFade = GameObject.Find("OT").GetComponent<Fade>();
			Destroy(areaFade);
		}

		if (GameInformation.RHComplete)
		{
			areaRenderer = GameObject.Find("RH").GetComponent<Renderer>();
			areaRenderer.material.SetColor("_EmissionColor", completeColor);
			areaFade = GameObject.Find("RH").GetComponent<Fade>();
			Destroy(areaFade);
		}

		if (GameInformation.IFGComplete)
		{
			areaRenderer = GameObject.Find("IFG").GetComponent<Renderer>();
			areaRenderer.material.SetColor("_EmissionColor", completeColor);
			areaFade = GameObject.Find("IFG").GetComponent<Fade>();
			Destroy(areaFade);
		}

		if (GameInformation.TPJComplete && GameInformation.OTComplete && GameInformation.RHComplete && GameInformation.IFGComplete)
		{
			GameInformation.AllAreasComplete = true;
			SaveInformation.SaveAllInformation();
		}
	}

	private void EnableInterventionButton()
	{
		interventionButton.SetActive(true);
		help1.SetActive(false);
		help2.SetActive(false);
	}

	private void EnableTestButton()
	{
		testButton.SetActive(true);
		help1.SetActive(false);
		help2.SetActive(false);
	}
}
