using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;

public class PreQuestionDB : MonoBehaviour 
{

	private List<Dictionary<string, string>> preQuestionDictionaries = new List<Dictionary<string, string>>();
	private Dictionary<string, string> preQuestionDictionary = new Dictionary<string, string>();

	public TextAsset preQuestionDatabase;
	public static List<PreQuestion> preQuestions = new List<PreQuestion>();
	public static List<PreQuestion> preDefQuestions = new List<PreQuestion>();
	public static List<PreQuestion> preNeuroQuestions = new List<PreQuestion>();
	public static List<PreQuestion> preAppQuestions = new List<PreQuestion>();
	public static List<PreQuestion> preMythQuestions = new List<PreQuestion>();


	// Use this for initialization
	void Awake () 
	{
		
		ReadPreQuestionsFromDatabase();

		for (int i = 0; i < preQuestionDictionaries.Count; i++)
		{
			preQuestions.Add(new PreQuestion(preQuestionDictionaries[i]));
		}

		for (int i = 0; i < 8; i++)
		{
			preDefQuestions.Add(new PreQuestion(preQuestionDictionaries[i]));
		}

		for (int i = 8; i < 15; i++)
		{
			preNeuroQuestions.Add(new PreQuestion(preQuestionDictionaries[i]));
		}

		for (int i = 15; i < 23; i++)
		{
			preAppQuestions.Add(new PreQuestion(preQuestionDictionaries[i]));
		}

		for (int i = 23; i < 32; i++)
		{
			preMythQuestions.Add(new PreQuestion(preQuestionDictionaries[i]));
		}
	}
	
	public void ReadPreQuestionsFromDatabase()
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(preQuestionDatabase.text);
		XmlNodeList preQuestionList = xmlDocument.GetElementsByTagName("PreQuestion");

		foreach (XmlNode preQuestionInfo in preQuestionList)
		{
			XmlNodeList preQuestionContent = preQuestionInfo.ChildNodes;
			preQuestionDictionary = new Dictionary<string, string>();

			foreach (XmlNode content in preQuestionContent)
			{
				switch(content.Name)
				{
					case "QuestionText":
						preQuestionDictionary.Add("QuestionText", content.InnerText);
						break;
					case "CorrectAnswer":
						preQuestionDictionary.Add("CorrectAnswer", content.InnerText);
						break;
					case "ID":
						preQuestionDictionary.Add("ID", content.InnerText);
						break;
					case "Explanation":
						preQuestionDictionary.Add("Explanation", content.InnerText);
						break;			
				}
			}

			preQuestionDictionaries.Add(preQuestionDictionary);
		}
	}
}
