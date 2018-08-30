﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class PreQuestion
{

	private string _questionText;
	private bool _correctAnswer;
	private int _ID;

	public PreQuestion(Dictionary<string, string> preQuestionDictionary)
	{
		_questionText = preQuestionDictionary["QuestionText"];
		_correctAnswer = bool.Parse(preQuestionDictionary["CorrectAnswer"]);
		_ID = int.Parse(preQuestionDictionary["ID"]);
	}

	public string QuestionText
	{
		get { return _questionText; }
		set { _questionText = value; }
	}

	public bool CorrectAnswer
	{
		get { return _correctAnswer; }
		set { _correctAnswer = value; }
	}

	public int ID
	{
		get { return _ID; }
		set { _ID = value; }
	}
}
