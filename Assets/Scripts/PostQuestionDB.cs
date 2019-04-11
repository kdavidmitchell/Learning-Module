using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;

public class PostQuestionDB : MonoBehaviour 
{

	private List<Dictionary<string, string>> postQuestionDictionaries = new List<Dictionary<string, string>>();
	private Dictionary<string, string> postQuestionDictionary = new Dictionary<string, string>();

	public TextAsset postQuestionDatabase;
	public static List<PostQuestion> postQuestions = new List<PostQuestion>();
	public static List<PostQuestion> postDefQuestions = new List<PostQuestion>();
	public static List<PostQuestion> postNeuroQuestions = new List<PostQuestion>();
	public static List<PostQuestion> postAppQuestions = new List<PostQuestion>();
	public static List<PostQuestion> postMythQuestions = new List<PostQuestion>();



	// Use this for initialization
	void Awake () 
	{
		
		ReadPostQuestionsFromDatabase();

		for (int i = 0; i < postQuestionDictionaries.Count; i++)
		{
			postQuestions.Add(new PostQuestion(postQuestionDictionaries[i]));
		}

		for (int i = 0; i < 8; i++)
		{
			postDefQuestions.Add(new PostQuestion(postQuestionDictionaries[i]));
		}

		for (int i = 8; i < 15; i++)
		{
			postNeuroQuestions.Add(new PostQuestion(postQuestionDictionaries[i]));
		}

		for (int i = 15; i < 23; i++)
		{
			postAppQuestions.Add(new PostQuestion(postQuestionDictionaries[i]));
		}

		for (int i = 23; i < 32; i++)
		{
			postMythQuestions.Add(new PostQuestion(postQuestionDictionaries[i]));
		}
	}
	
	public void ReadPostQuestionsFromDatabase()
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(postQuestionDatabase.text);
		XmlNodeList preQuestionList = xmlDocument.GetElementsByTagName("PostQuestion");

		foreach (XmlNode preQuestionInfo in preQuestionList)
		{
			XmlNodeList preQuestionContent = preQuestionInfo.ChildNodes;
			postQuestionDictionary = new Dictionary<string, string>();

			foreach (XmlNode content in preQuestionContent)
			{
				switch(content.Name)
				{
					case "QuestionText":
						postQuestionDictionary.Add("QuestionText", content.InnerText);
						break;
					case "CorrectAnswer":
						postQuestionDictionary.Add("CorrectAnswer", content.InnerText);
						break;
					case "ID":
						postQuestionDictionary.Add("ID", content.InnerText);
						break;
					case "Explanation":
						postQuestionDictionary.Add("Explanation", content.InnerText);
						break;			
				}
			}

			postQuestionDictionaries.Add(postQuestionDictionary);
		}
	}
}
