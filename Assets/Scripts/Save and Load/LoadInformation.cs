using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        Debug.Log("LOADED ALL INFORMATION.");
    }
}
