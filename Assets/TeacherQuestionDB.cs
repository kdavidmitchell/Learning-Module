using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;

public class TeacherQuestionDB : MonoBehaviour 
{

	private List<Dictionary<string, string>> teacherQuestionDictionaries = new List<Dictionary<string, string>>();
	private Dictionary<string, string> teacherQuestionDictionary = new Dictionary<string, string>();
	private int numResponses;

	public TextAsset teacherQuestionDatabase;
	public static List<SurveyQuestion> teacherQuestions = new List<SurveyQuestion>();

	// Use this for initialization
	void Awake () 
	{
		ReadTeacherQuestionsFromDatabase();

		for (int i = 0; i < teacherQuestionDictionaries.Count; i++)
		{
			teacherQuestions.Add(new SurveyQuestion(teacherQuestionDictionaries[i]));
		}
	}
	
	public void ReadTeacherQuestionsFromDatabase()
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(teacherQuestionDatabase.text);
		XmlNodeList teacherQuestionList = xmlDocument.GetElementsByTagName("TeacherQuestion");

		foreach (XmlNode teacherQuestionInfo in teacherQuestionList)
		{
			XmlNodeList teacherQuestionContent = teacherQuestionInfo.ChildNodes;
			teacherQuestionDictionary = new Dictionary<string, string>();

			foreach (XmlNode content in teacherQuestionContent)
			{
				switch(content.Name)
				{
					case "QuestionText":
						teacherQuestionDictionary.Add("QuestionText", content.InnerText);
						break;
					case "NumResponses":
						teacherQuestionDictionary.Add("NumResponses", content.InnerText);
						numResponses = int.Parse(teacherQuestionDictionary["NumResponses"]);
						break;
					case "ID":
						teacherQuestionDictionary.Add("ID", content.InnerText);
						break;
					case "HasWriteIn":
						teacherQuestionDictionary.Add("HasWriteIn", content.InnerText);
						break;
					case "CanSkip":
						teacherQuestionDictionary.Add("CanSkip", content.InnerText);
						break;
					case "AllowsMultipleAnswers":
						teacherQuestionDictionary.Add("AllowsMultipleAnswers", content.InnerText);
						break;			
				}

				for (int i = 1; i < numResponses + 1; i++) 
				{
					if (content.Name == ("Response" + i))
					{
						teacherQuestionDictionary.Add(("Response" + i), content.InnerText);
					}
				}
			}

			teacherQuestionDictionaries.Add(teacherQuestionDictionary);
		}
	}
}
