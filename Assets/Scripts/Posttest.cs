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
	private GameObject submitButton;
	private GameObject certaintyRating;
	private Toggle rating0;
	private Toggle rating1;
	private Toggle rating2;
	private GameObject endText;
	private GameObject paper;
	private Image progressFill;

	private int questionIndex = 0;
	private bool currentAnswer = false;
	private List<List<PostQuestion>> blocks = new List<List<PostQuestion>>();
	private List<List<PostQuestion>> shuffledBlocks = new List<List<PostQuestion>>();
	private List<PostQuestion> shuffledQuestions = new List<PostQuestion>();
	private float completionTime = 0f;
	private bool done = false;

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
		endText = GameObject.Find("BodyBorder");
		paper = GameObject.Find("Paper");
		progressFill = GameObject.Find("Fill").GetComponent<Image>();

		nextSceneButton.SetActive(false);
		submitButton.SetActive(false);
		certaintyRating.SetActive(false);
		endText.SetActive(false);
		ShuffleQuestions();
		DisplayNextQuestion();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!done)
		{
			completionTime += Time.deltaTime;
		}
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
		blocks.Add(PostQuestionDB.postDefQuestions.OrderBy(x => Random.value).ToList());
		blocks.Add(PostQuestionDB.postNeuroQuestions.OrderBy(x => Random.value).ToList());
		blocks.Add(PostQuestionDB.postAppQuestions.OrderBy(x => Random.value).ToList());
		blocks.Add(PostQuestionDB.postMythQuestions.OrderBy(x => Random.value).ToList());

		shuffledBlocks = blocks.OrderBy(x => Random.value).ToList();

		foreach (List<PostQuestion> l in shuffledBlocks)
		{
			foreach (PostQuestion q in l)
			{
				shuffledQuestions.Add(q);
			}
		}

		GameInformation.PostOrder = shuffledQuestions;
		SaveInformation.SaveAllInformation();
	}

	public void ScoreAnswerAndContinue()
	{
		if (currentAnswer == true)
		{
			if (trueToggle.isOn)
			{
				Debug.Log("Correct!");
				GameInformation.CorrectPostQuestions.Add(shuffledQuestions[questionIndex - 1]);
				Debug.Log(GameInformation.CorrectPostQuestions.Count);
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
				GameInformation.CorrectPostQuestions.Add(shuffledQuestions[questionIndex - 1]);
				Debug.Log(GameInformation.CorrectPostQuestions.Count);
			} else 
			{
				Debug.Log("Incorrect. :(");
				GameInformation.PostQuestions.Add(shuffledQuestions[questionIndex - 1]);	
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
			progressFill.fillAmount = ((float)questionIndex / (float)shuffledQuestions.Count);
			DisplayNextQuestion();
		} else 
		{
			for (int i = 0; i < GameInformation.PostCertainty.Length; i++) 
			{
				Debug.Log(GameInformation.PostCertainty[i].ToString());
			}
			progressFill.fillAmount = ((float)questionIndex / (float)shuffledQuestions.Count);
			paper.SetActive(false);
			endText.SetActive(true);
			nextSceneButton.SetActive(true);
			done = true;
			GameInformation.PostCompletionTime = completionTime;	
		}

		SaveInformation.SaveAllInformation();
		Debug.Log(GameInformation.PostQuestions.Count);
	}

	public void SaveCertaintyRating()
	{
		if (rating0.isOn)
		{
			GameInformation.PostCertainty[questionIndex - 1] = 0;
		} else if (rating1.isOn)
		{
			GameInformation.PostCertainty[questionIndex - 1] = 1;
		} else if (rating2.isOn)
		{
			GameInformation.PostCertainty[questionIndex - 1] = 2;
		}

	}
}
