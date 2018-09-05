using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SurveyQuestion 
{

	private string _questionText;
	private int _ID;
	private int _numResponses;
	private List<string> _responses;
	private bool _hasWriteIn;

	public SurveyQuestion(Dictionary<string, string> surveyQuestionDictionary)
	{
		_questionText = surveyQuestionDictionary["QuestionText"];
		_hasWriteIn = bool.Parse(surveyQuestionDictionary["HasWriteIn"]);
		_ID = int.Parse(surveyQuestionDictionary["ID"]);
		_numResponses = int.Parse(surveyQuestionDictionary["NumResponses"]);
		_responses = new List<string>();

		for (int i = 1; i < _numResponses + 1; i++) 
		{
			_responses.Add(surveyQuestionDictionary[("Response" + i)]);
		}
	}

	public string QuestionText
	{
		get { return _questionText; }
		set { _questionText = value; }
	}

	public int ID
	{
		get { return _ID; }
		set { _ID = value; }
	}

	public int NumResponses
	{
		get { return _numResponses; }
		set { _numResponses = value; }
	}

	public List<string> Responses
	{
		get { return _responses; }
		set { _responses = value; }
	}

	public bool HasWriteIn
	{
		get { return _hasWriteIn; }
		set {_hasWriteIn = value; }
	}
}
