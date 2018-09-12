using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SaveInformation 
{

	public static void SaveAllInformation()
    {

        if (GameInformation.PreQuestions != null)
        {
        	PPSerialization.Save("PRE_QUESTIONS", GameInformation.PreQuestions);
        }

        if (GameInformation.PostQuestions != null)
        {
        	PPSerialization.Save("POST_QUESTIONS", GameInformation.PostQuestions);
        }

        if (GameInformation.TPJComplete != null)
        {
            PlayerPrefs.SetInt("TPJ_COMPLETE", Convert.ToInt32(GameInformation.TPJComplete));
        }

        if (GameInformation.AllAreasComplete != null)
        {
            PlayerPrefs.SetInt("ALL_AREAS_COMPLETE", Convert.ToInt32(GameInformation.AllAreasComplete));
        }
        
        Debug.Log("SAVED ALL INFORMATION.");
    }
}
