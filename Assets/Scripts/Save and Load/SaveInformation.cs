using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
        Debug.Log("SAVED ALL INFORMATION.");
    }
}
