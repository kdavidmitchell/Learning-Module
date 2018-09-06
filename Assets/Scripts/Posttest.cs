using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Posttest : MonoBehaviour 
{

	private Text questionText;
	private Toggle trueToggle;
	private Toggle falseToggle;
	private GameObject nextSceneButton;

	private int questionIndex = 0;
	private bool currentAnswer = false;
	private List<PostQuestion> shuffledQuestions = new List<PostQuestion>();

	// Use this for initialization
	void Start () 
	{
		questionText = GameObject.Find("Question").GetComponent<Text>();
		trueToggle = GameObject.Find("TrueToggle").GetComponent<Toggle>();
		falseToggle = GameObject.Find("FalseToggle").GetComponent<Toggle>();
		nextSceneButton = GameObject.Find("NextSceneButton");

		nextSceneButton.SetActive(false);
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
		shuffledQuestions = PostQuestionDB.postQuestions.OrderBy(x => Random.value).ToList();
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
				GameInformation.PostQuestions.Add(shuffledQuestions[questionIndex - 1]);	
			}
		} else 
		{
			if (falseToggle.isOn)
			{
				Debug.Log("Correct!");
			} else 
			{
				Debug.Log("Incorrect. :(");
				GameInformation.PostQuestions.Add(shuffledQuestions[questionIndex - 1]);	
			}	
		}

		if (questionIndex != shuffledQuestions.Count)
		{
			DisplayNextQuestion();
		} else 
		{
			nextSceneButton.SetActive(true);	
		}

		SaveInformation.SaveAllInformation();
		Debug.Log(GameInformation.PostQuestions.Count);
	}
}
