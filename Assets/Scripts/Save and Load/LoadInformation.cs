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

        if (PlayerPrefs.GetString("CORRECT_POST_QUESTIONS") != null)
        {
            GameInformation.CorrectPostQuestions = (List<PostQuestion>)PPSerialization.Load("CORRECT_POST_QUESTIONS");
        }

        if (PlayerPrefs.GetString("SURVEY_QUESTIONS") != null)
        {
            GameInformation.SurveyQuestions = (Dictionary<int, List<string>>)PPSerialization.Load("SURVEY_QUESTIONS");
        }

        if (PlayerPrefs.GetString("TEACHER_QUESTIONS") != null)
        {
            GameInformation.TeacherQuestions = (Dictionary<int, List<string>>)PPSerialization.Load("TEACHER_QUESTIONS");
        }

        if (PlayerPrefs.GetString("PRE_CERTAINTY") != null)
        {
            GameInformation.PreCertainty = (int[])PPSerialization.Load("PRE_CERTAINTY");
        }

        if (PlayerPrefs.GetString("POST_CERTAINTY") != null)
        {
            GameInformation.PostCertainty = (int[])PPSerialization.Load("POST_CERTAINTY");
        }

        if (PlayerPrefs.GetInt("TPJ_COMPLETE") != null)
        {
            GameInformation.TPJComplete = Convert.ToBoolean(PlayerPrefs.GetInt("TPJ_COMPLETE"));
        }

        if (PlayerPrefs.GetInt("ALL_AREAS_COMPLETE") != null)
        {
            GameInformation.AllAreasComplete = Convert.ToBoolean(PlayerPrefs.GetInt("ALL_AREAS_COMPLETE"));
        }

        if (PlayerPrefs.GetInt("INTERVENTION_COMPLETE") != null)
        {
            GameInformation.InterventionComplete = Convert.ToBoolean(PlayerPrefs.GetInt("INTERVENTION_COMPLETE"));
        }

        //Options

        if (PlayerPrefs.GetInt("COLORBLIND_MODE") != null)
        {
            GameInformation.ColorblindMode = Convert.ToBoolean(PlayerPrefs.GetInt("COLORBLIND_MODE"));
        }

        Debug.Log("LOADED ALL INFORMATION.");
    }
}
