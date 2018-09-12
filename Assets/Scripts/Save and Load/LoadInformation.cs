using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoadInformation 
{

	public static void LoadAllInformation()
    {

        if (PlayerPrefs.GetString("PRE_QUESTIONS") != null)
        {
            GameInformation.PreQuestions = (List<PreQuestion>)PPSerialization.Load("PRE_QUESTIONS");
        }

        if (PlayerPrefs.GetString("POST_QUESTIONS") != null)
        {
            GameInformation.PostQuestions = (List<PostQuestion>)PPSerialization.Load("POST_QUESTIONS");
        }

        if (PlayerPrefs.GetInt("TPJ_COMPLETE") != null)
        {
            GameInformation.TPJComplete = Convert.ToBoolean(PlayerPrefs.GetInt("TPJ_COMPLETE"));
        }

        if (PlayerPrefs.GetInt("ALL_AREAS_COMPLETE") != null)
        {
            GameInformation.AllAreasComplete = Convert.ToBoolean(PlayerPrefs.GetInt("ALL_AREAS_COMPLETE"));
        }

        Debug.Log("LOADED ALL INFORMATION.");
    }
}
