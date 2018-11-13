using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;

public class SurveyQuestionDB : MonoBehaviour 
{

	private List<Dictionary<string, string>> surveyQuestionDictionaries = new List<Dictionary<string, string>>();
	private Dictionary<string, string> surveyQuestionDictionary = new Dictionary<string, string>();
	private int numResponses;

	public TextAsset surveyQuestionDatabase;
	public static List<SurveyQuestion> surveyQuestions = new List<SurveyQuestion>();

	// Use this for initialization
	void Awake () 
	{
		ReadSurveyQuestionsFromDatabase();

		for (int i = 0; i < surveyQuestionDictionaries.Count; i++)
		{
			surveyQuestions.Add(new SurveyQuestion(surveyQuestionDictionaries[i]));
		}
	}
	
	public void ReadSurveyQuestionsFromDatabase()
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(surveyQuestionDatabase.text);
		XmlNodeList surveyQuestionList = xmlDocument.GetElementsByTagName("SurveyQuestion");

		foreach (XmlNode surveyQuestionInfo in surveyQuestionList)
		{
			XmlNodeList surveyQuestionContent = surveyQuestionInfo.ChildNodes;
			surveyQuestionDictionary = new Dictionary<string, string>();

			foreach (XmlNode content in surveyQuestionContent)
			{
				switch(content.Name)
				{
					case "QuestionText":
						surveyQuestionDictionary.Add("QuestionText", content.InnerText);
						break;
					case "NumResponses":
						surveyQuestionDictionary.Add("NumResponses", content.InnerText);
						numResponses = int.Parse(surveyQuestionDictionary["NumResponses"]);
						break;
					case "ID":
						surveyQuestionDictionary.Add("ID", content.InnerText);
						break;
					case "HasWriteIn":
						surveyQuestionDictionary.Add("HasWriteIn", content.InnerText);
						break;
					case "CanSkip":
						surveyQuestionDictionary.Add("CanSkip", content.InnerText);
						break;
					case "AllowsMultipleAnswers":
						surveyQuestionDictionary.Add("AllowsMultipleAnswers", content.InnerText);
						break;			
				}

				for (int i = 1; i < numResponses + 1; i++) 
				{
					if (content.Name == ("Response" + i))
					{
						surveyQuestionDictionary.Add(("Response" + i), content.InnerText);
					}
				}
			}

			surveyQuestionDictionaries.Add(surveyQuestionDictionary);
		}
	}
}
