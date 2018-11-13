using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeacherScreen : MonoBehaviour 
{

	private GameObject submitButton;
	private Text questionText;
	private GameObject answerText;
	private GameObject nextSceneButton;
	private ToggleGroup currentToggleGroup;
	private InputField currentInputField;
	private List<Toggle> currentToggleList = new List<Toggle>();

	private List<SurveyQuestion> questions = new List<SurveyQuestion>();
	private int numResponses;
	private int questionIndex = 0;

	public GameObject togglePrefab;
	public GameObject inputPrefab;
	public GameObject skipAlert;
	public GameObject finishedSurveyAlert;

	// Use this for initialization
	void Start () 
	{
		submitButton = GameObject.Find("ButtonBorder");
		questionText = GameObject.Find("QuestionText").GetComponent<Text>();
		answerText = GameObject.Find("AnswerText");
		nextSceneButton = GameObject.Find("NextSceneButton");
		questions = TeacherQuestionDB.teacherQuestions;

		skipAlert.SetActive(false);
		finishedSurveyAlert.SetActive(false);
		
		Continue();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void Continue()
	{
		currentToggleGroup = null;
		currentInputField = null;
		currentToggleList.Clear();

		if (questionIndex != questions.Count)
		{
			numResponses = questions[questionIndex].NumResponses;
			questionText.text = questions[questionIndex].QuestionText;

			if (questions[questionIndex].HasWriteIn && questions[questionIndex].AllowsMultipleAnswers)
			{
				for (int i = 0; i < numResponses - 1; i++) 
				{
					GameObject currentToggle = Instantiate(togglePrefab, answerText.transform.position, Quaternion.identity);
					currentToggle.transform.SetParent(answerText.transform, false);
					Toggle toggleComponent = currentToggle.GetComponent<Toggle>();
					currentToggleList.Add(toggleComponent);
					//toggleComponent.onValueChanged.AddListener((bool on) => submitButton.SetActive(!submitButton.active));
					Text toggleText = toggleComponent.GetComponentInChildren<Text>();
					toggleText.text = questions[questionIndex].Responses[i];
				}

				GameObject currentInput = Instantiate(inputPrefab, answerText.transform.position, Quaternion.identity);
				currentInput.transform.SetParent(answerText.transform, false);
				InputField inputFieldComponent = currentInput.GetComponentInChildren<InputField>();
				Text textComponent = currentInput.GetComponentInChildren<Text>();
				textComponent.text = questions[questionIndex].Responses[numResponses - 1];
				currentInputField = currentInput.GetComponentInChildren<InputField>();
			} else if (questions[questionIndex].HasWriteIn && !questions[questionIndex].AllowsMultipleAnswers)
			{
				for (int i = 0; i < numResponses - 1; i++) 
				{
					GameObject currentToggle = Instantiate(togglePrefab, answerText.transform.position, Quaternion.identity);
					currentToggle.transform.SetParent(answerText.transform, false);
					Toggle toggleComponent = currentToggle.GetComponent<Toggle>();
					toggleComponent.group = answerText.GetComponent<ToggleGroup>();
					//toggleComponent.onValueChanged.AddListener((bool on) => submitButton.SetActive(!submitButton.active));
					Text toggleText = toggleComponent.GetComponentInChildren<Text>();
					toggleText.text = questions[questionIndex].Responses[i];
					currentToggleGroup = answerText.GetComponent<ToggleGroup>();
				}

				GameObject currentInput = Instantiate(inputPrefab, answerText.transform.position, Quaternion.identity);
				currentInput.transform.SetParent(answerText.transform, false);
				InputField inputFieldComponent = currentInput.GetComponentInChildren<InputField>();
				Text textComponent = currentInput.GetComponentInChildren<Text>();
				textComponent.text = questions[questionIndex].Responses[numResponses - 1];
				currentInputField = currentInput.GetComponentInChildren<InputField>();
			} else if (!questions[questionIndex].HasWriteIn && !questions[questionIndex].AllowsMultipleAnswers)
			{
				for (int i = 0; i < numResponses; i++) 
				{
					GameObject currentToggle = Instantiate(togglePrefab, answerText.transform.position, Quaternion.identity);
					currentToggle.transform.SetParent(answerText.transform, false);
					Toggle toggleComponent = currentToggle.GetComponent<Toggle>();
					toggleComponent.group = answerText.GetComponent<ToggleGroup>();
					//toggleComponent.onValueChanged.AddListener((bool on) => submitButton.SetActive(!submitButton.active));
					Text toggleText = toggleComponent.GetComponentInChildren<Text>();
					toggleText.text = questions[questionIndex].Responses[i];
					currentToggleGroup = answerText.GetComponent<ToggleGroup>();
				}
			} else 
			{
				for (int i = 0; i < numResponses; i++) 
				{
					GameObject currentToggle = Instantiate(togglePrefab, answerText.transform.position, Quaternion.identity);
					currentToggle.transform.SetParent(answerText.transform, false);
					Toggle toggleComponent = currentToggle.GetComponent<Toggle>();
					currentToggleList.Add(toggleComponent);
					//toggleComponent.onValueChanged.AddListener((bool on) => submitButton.SetActive(!submitButton.active));
					Text toggleText = toggleComponent.GetComponentInChildren<Text>();
					toggleText.text = questions[questionIndex].Responses[i];
				}	
			}
			
			questionIndex++;
		} else 
		{
			submitButton.SetActive(false);
			finishedSurveyAlert.SetActive(true);
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

	public void SaveAnswer()
	{
		int questionNum = questionIndex - 1;
		List<string> answers = new List<string>();

		if (currentToggleGroup != null)
		{
			foreach (Toggle t in currentToggleGroup.ActiveToggles())
			{
				if (t.isOn)
				{
					answers.Add(t.GetComponentInChildren<Text>().text);
				}
			}
		}

		if (currentInputField != null)
		{
			answers.Add(currentInputField.text);
		}

		if (currentToggleList.Count != 0)
		{
			foreach (Toggle t in currentToggleList)
			{
				if (t.isOn)
				{
					answers.Add(t.GetComponentInChildren<Text>().text);
				}
			}
		}

		GameInformation.TeacherQuestions.Add(questionNum, answers);
		SaveInformation.SaveAllInformation();
	}

	public void CheckIfSkippable()
	{
		if (questions[questionIndex - 1].CanSkip)
		{
			SaveAnswer();
			DestroyToggles();
			Continue();
		} else 
		{
			if (currentToggleGroup != null && currentInputField != null)
			{
				if (!currentToggleGroup.AnyTogglesOn() && currentInputField.text == "")
				{
					skipAlert.SetActive(true);
					submitButton.SetActive(false);
				} else 
				{
					SaveAnswer();
					DestroyToggles();
					Continue();	
				}

			} else if (currentToggleGroup != null && currentInputField == null)
			{
				if (!currentToggleGroup.AnyTogglesOn())
				{
					skipAlert.SetActive(true);
					submitButton.SetActive(false);
				} else 
				{
					SaveAnswer();
					DestroyToggles();
					Continue();	
				}
			} else if (currentToggleGroup == null && currentInputField != null && currentToggleList.Count == 0)
			{
				if (currentInputField.text == "")
				{
					skipAlert.SetActive(true);
					submitButton.SetActive(false);
				} else
				{
					SaveAnswer();
					DestroyToggles();
					Continue();
				}
			} else if (currentToggleList.Count != 0 && currentInputField != null && currentToggleGroup == null)
			{
				if ((CheckIfAnyTogglesAreOn(currentToggleList) == true) || currentInputField.text != "")
				{
					SaveAnswer();
					DestroyToggles();
					Continue();
				} else 
				{
					skipAlert.SetActive(true);
					submitButton.SetActive(false);	
				}
			} else if (currentToggleList.Count != 0 && currentInputField == null)
			{
				if (CheckIfAnyTogglesAreOn(currentToggleList) == false)
				{
					skipAlert.SetActive(true);
					submitButton.SetActive(false);
				} else 
				{
					SaveAnswer();
					DestroyToggles();
					Continue();	
				}
			} else if (currentToggleList.Count == 0 && currentInputField != null)
			{
				if (currentInputField.text == "")
				{
					skipAlert.SetActive(true);
					submitButton.SetActive(false);
				} else
				{
					SaveAnswer();
					DestroyToggles();
					Continue();
				}
			}		
		}
	}

	public bool CheckIfAnyTogglesAreOn(List<Toggle> toggleList)
	{
		Debug.Log("I have been called");
		foreach (Toggle t in toggleList)
		{
			if (t.isOn)
			{
				return true;
			}
		}

		return false;
	}
}
