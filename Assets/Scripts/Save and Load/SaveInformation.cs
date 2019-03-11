﻿using System.Collections;
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

        if (GameInformation.CorrectPostQuestions != null)
        {
            PPSerialization.Save("CORRECT_POST_QUESTIONS", GameInformation.CorrectPostQuestions);
        }

        if (GameInformation.SurveyQuestions != null)
        {
            PPSerialization.Save("SURVEY_QUESTIONS", GameInformation.SurveyQuestions);
        }

        if (GameInformation.TeacherQuestions != null)
        {
            PPSerialization.Save("TEACHER_QUESTIONS", GameInformation.TeacherQuestions);
        }

        if (GameInformation.PreCertainty != null)
        {
            PPSerialization.Save("PRE_CERTAINTY", GameInformation.PreCertainty);
        }

        if (GameInformation.PostCertainty != null)
        {
            PPSerialization.Save("POST_CERTAINTY", GameInformation.PostCertainty);
        }

        if (GameInformation.TPJComplete != null)
        {
            PlayerPrefs.SetInt("TPJ_COMPLETE", Convert.ToInt32(GameInformation.TPJComplete));
        }
        
        if (GameInformation.OTComplete != null)
        {
            PlayerPrefs.SetInt("OT_COMPLETE", Convert.ToInt32(GameInformation.OTComplete));
        }

        if (GameInformation.RHComplete != null)
        {
            PlayerPrefs.SetInt("RH_COMPLETE", Convert.ToInt32(GameInformation.RHComplete));
        }

        if (GameInformation.IFGComplete != null)
        {
            PlayerPrefs.SetInt("IFG_COMPLETE", Convert.ToInt32(GameInformation.IFGComplete));
        }

        if (GameInformation.AllAreasComplete != null)
        {
            PlayerPrefs.SetInt("ALL_AREAS_COMPLETE", Convert.ToInt32(GameInformation.AllAreasComplete));
        }

        if (GameInformation.InterventionComplete != null)
        {
            PlayerPrefs.SetInt("INTERVENTION_COMPLETE", Convert.ToInt32(GameInformation.InterventionComplete));
        }

        //Options

        if (GameInformation.ColorblindMode != null)
        {
            PlayerPrefs.SetInt("COLORBLIND_MODE", Convert.ToInt32(GameInformation.ColorblindMode));
        }

        if (GameInformation.SpeechAutoPlay != null)
        {
            PlayerPrefs.SetInt("SPEECH_AUTOPLAY", Convert.ToInt32(GameInformation.SpeechAutoPlay));
        }
        
        Debug.Log("SAVED ALL INFORMATION.");
    }
}
