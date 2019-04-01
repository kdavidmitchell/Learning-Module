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

        if (PlayerPrefs.GetString("CORRECT_PRE_QUESTIONS") != null)
        {
            GameInformation.CorrectPreQuestions = (List<PreQuestion>)PPSerialization.Load("CORRECT_PRE_QUESTIONS");
        }

        if (PlayerPrefs.GetString("CORRECT_POST_QUESTIONS") != null)
        {
            GameInformation.CorrectPostQuestions = (List<PostQuestion>)PPSerialization.Load("CORRECT_POST_QUESTIONS");
        }

        if (PlayerPrefs.GetString("PRE_ORDER") != null)
        {
            GameInformation.PreOrder = (List<PreQuestion>)PPSerialization.Load("PRE_ORDER");
        }

        if (PlayerPrefs.GetString("POST_ORDER") != null)
        {
            GameInformation.PostOrder = (List<PostQuestion>)PPSerialization.Load("POST_ORDER");
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

        if (PlayerPrefs.GetInt("OT_COMPLETE") != null)
        {
            GameInformation.OTComplete = Convert.ToBoolean(PlayerPrefs.GetInt("OT_COMPLETE"));
        }

        if (PlayerPrefs.GetInt("RH_COMPLETE") != null)
        {
            GameInformation.RHComplete = Convert.ToBoolean(PlayerPrefs.GetInt("RH_COMPLETE"));
        }

        if (PlayerPrefs.GetInt("IFG_COMPLETE") != null)
        {
            GameInformation.IFGComplete = Convert.ToBoolean(PlayerPrefs.GetInt("IFG_COMPLETE"));
        }

        if (PlayerPrefs.GetInt("ALL_AREAS_COMPLETE") != null)
        {
            GameInformation.AllAreasComplete = Convert.ToBoolean(PlayerPrefs.GetInt("ALL_AREAS_COMPLETE"));
        }

        if (PlayerPrefs.GetInt("INTERVENTION_COMPLETE") != null)
        {
            GameInformation.InterventionComplete = Convert.ToBoolean(PlayerPrefs.GetInt("INTERVENTION_COMPLETE"));
        }

        if (PlayerPrefs.GetFloat("PRE_COMPLETION_TIME") != null)
        {
            GameInformation.PreCompletionTime = PlayerPrefs.GetFloat("PRE_COMPLETION_TIME");
        }

        if (PlayerPrefs.GetFloat("POST_COMPLETION_TIME") != null)
        {
            GameInformation.PostCompletionTime = PlayerPrefs.GetFloat("POST_COMPLETION_TIME");
        }

        if (PlayerPrefs.GetFloat("TOTAL_COMPLETION_TIME") != null)
        {
            GameInformation.TotalCompletionTime = PlayerPrefs.GetFloat("TOTAL_COMPLETION_TIME");
        }

        //Options

        if (PlayerPrefs.GetInt("COLORBLIND_MODE") != null)
        {
            GameInformation.ColorblindMode = Convert.ToBoolean(PlayerPrefs.GetInt("COLORBLIND_MODE"));
        }

        if (PlayerPrefs.GetInt("SPEECH_AUTOPLAY") != null)
        {
            GameInformation.SpeechAutoPlay = Convert.ToBoolean(PlayerPrefs.GetInt("SPEECH_AUTOPLAY"));
        }

        Debug.Log("LOADED ALL INFORMATION.");
    }
}
