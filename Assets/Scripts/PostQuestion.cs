using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class PostQuestion
{

	private string _questionText;
	private bool _correctAnswer;
	private int _ID;
	private string _explanation;

	public PostQuestion(Dictionary<string, string> postQuestionDictionary)
	{
		_questionText = postQuestionDictionary["QuestionText"];
		_correctAnswer = bool.Parse(postQuestionDictionary["CorrectAnswer"]);
		_ID = int.Parse(postQuestionDictionary["ID"]);
		_explanation = postQuestionDictionary["Explanation"];
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

	public string Explanation
	{
		get { return _explanation; }
		set { _explanation = value; }
	}
}
