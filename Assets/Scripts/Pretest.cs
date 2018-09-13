﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Pretest : MonoBehaviour 
{

	private Text questionText;
	private Toggle trueToggle;
	private Toggle falseToggle;
	private GameObject nextSceneButton;
	private GameObject submitButton;
	private GameObject certaintyRating;
	private Toggle rating0;
	private Toggle rating1;
	private Toggle rating2;

	private int questionIndex = 0;
	private bool currentAnswer = false;
	private List<PreQuestion> shuffledQuestions = new List<PreQuestion>();

	// Use this for initialization
	void Start () 
	{
		questionText = GameObject.Find("Question").GetComponent<Text>();
		trueToggle = GameObject.Find("TrueToggle").GetComponent<Toggle>();
		falseToggle = GameObject.Find("FalseToggle").GetComponent<Toggle>();
		nextSceneButton = GameObject.Find("NextSceneButton");
		submitButton = GameObject.Find("SubmitButtonBorder");
		certaintyRating = GameObject.Find("CertaintyRatingBorder");
		rating0 = GameObject.Find("NotConfidentToggle").GetComponent<Toggle>();
		rating1 = GameObject.Find("SomewhatConfidentToggle").GetComponent<Toggle>();
		rating2 = GameObject.Find("VeryConfidentToggle").GetComponent<Toggle>();

		nextSceneButton.SetActive(false);
		submitButton.SetActive(false);
		certaintyRating.SetActive(false);
		ShuffleQuestions();
		DisplayNextQuestion();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void DisplayNextQuestion()
	{
		questionText.text = "Question " + (questionIndex+1) + ": " + 
			shuffledQuestions[questionIndex].QuestionText;

		currentAnswer = shuffledQuestions[questionIndex].CorrectAnswer;

		questionIndex++;
	}

	private void ShuffleQuestions()
	{
		shuffledQuestions = PreQuestionDB.preQuestions.OrderBy(x => Random.value).ToList();
	}

	public void ScoreAnswerAndContinue()
	{
		if (currentAnswer == true)
		{
			if (trueToggle.isOn)
			{
				Debug.Log("Correct!");
			} else 
			{
				Debug.Log("Incorrect. :(");
				GameInformation.PreQuestions.Add(shuffledQuestions[questionIndex - 1]);	
			}
		} else 
		{
			if (falseToggle.isOn)
			{
				Debug.Log("Correct!");
			} else 
			{
				Debug.Log("Incorrect. :(");
				GameInformation.PreQuestions.Add(shuffledQuestions[questionIndex - 1]);	
			}	
		}

		SaveCertaintyRating();
		trueToggle.isOn = false;
		falseToggle.isOn = false;
		rating0.isOn = false;
		rating1.isOn = false;
		rating2.isOn = false;

		if (questionIndex != shuffledQuestions.Count)
		{ 
			DisplayNextQuestion();
		} else 
		{
			for (int i = 0; i < GameInformation.PreCertainty.Length; i++) 
			{
				Debug.Log(GameInformation.PreCertainty[i].ToString());
			}

			nextSceneButton.SetActive(true);	
		}

		SaveInformation.SaveAllInformation();
		Debug.Log(GameInformation.PreQuestions.Count);
	}

	public void SaveCertaintyRating()
	{
		if (rating0.isOn)
		{
			GameInformation.PreCertainty[questionIndex - 1] = 0;
		} else if (rating1.isOn)
		{
			GameInformation.PreCertainty[questionIndex - 1] = 1;
		} else if (rating2.isOn)
		{
			GameInformation.PreCertainty[questionIndex - 1] = 2;
		}

	}
}
