using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SurveyScreen : MonoBehaviour 
{

	private GameObject submitButton;
	private Text questionText;
	private GameObject answerText;
	private GameObject nextSceneButton;

	private List<SurveyQuestion> questions = new List<SurveyQuestion>();
	private int numResponses;
	private int questionIndex = 0;

	public GameObject togglePrefab;

	// Use this for initialization
	void Start () 
	{
		submitButton = GameObject.Find("ButtonBorder");
		questionText = GameObject.Find("QuestionText").GetComponent<Text>();
		answerText = GameObject.Find("AnswerText");
		nextSceneButton = GameObject.Find("NextSceneButton");
		questions = SurveyQuestionDB.surveyQuestions;

		submitButton.SetActive(false);
		nextSceneButton.SetActive(false);
		
		Continue();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void SaveAnswer()
	{

	}

	public void Continue()
	{
		if (questionIndex != questions.Count)
		{
			numResponses = questions[questionIndex].NumResponses;
			questionText.text = questions[questionIndex].QuestionText;
			
			for (int i = 0; i < numResponses; i++) 
			{
				GameObject currentToggle = Instantiate(togglePrefab, answerText.transform.position, Quaternion.identity);
				currentToggle.transform.parent = answerText.transform;
				Toggle toggleComponent = currentToggle.GetComponent<Toggle>();
				toggleComponent.group = answerText.GetComponent<ToggleGroup>();
				toggleComponent.onValueChanged.AddListener((bool on) => submitButton.SetActive(true));
				Text toggleText = toggleComponent.GetComponentInChildren<Text>();
				toggleText.text = questions[questionIndex].Responses[i];
			}
			
			questionIndex++;
		} else 
		{
			Debug.Log("Reached end of survey, please continue to results!");
			submitButton.SetActive(false);
			nextSceneButton.SetActive(true);
		}
	}

	public void DestroyToggles()
	{
		GameObject[] toBeDestroyed = GameObject.FindGameObjectsWithTag("Destroy");
		for (int i = 0; i < toBeDestroyed.Length; i++) 
		{
			Destroy(toBeDestroyed[i]);
		}
	}
}
