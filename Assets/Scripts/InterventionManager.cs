using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterventionManager : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		GameInformation.InterventionComplete = true;
		SaveInformation.SaveAllInformation();	
	}
}
