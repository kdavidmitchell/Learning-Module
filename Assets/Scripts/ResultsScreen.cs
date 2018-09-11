using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsScreen : MonoBehaviour 
{

	private GameObject pretestContent;
	private GameObject posttestConent;
	private Text preScore;
	private Text postScore;
	private int numPreQuestions = 2;
	private int numPostQuestions = 2;

	public GameObject questionPrefab;
	public GameObject explanationPrefab;

	// Use this for initialization
	void Start () 
	{
		pretestContent = GameObject.Find("PretestContent");
		posttestConent = GameObject.Find("PosttestContent");
		preScore = GameObject.Find("PretestScore").GetComponent<Text>();
		postScore = GameObject.Find("PosttestScore").GetComponent<Text>();

		for (int i = 0; i < GameInformation.PreQuestions.Count; i++) 
		{
			GameObject questionToBeInstantiated = Instantiate(questionPrefab, pretestContent.transform.position, Quaternion.identity);
			GameObject explanationToBeInstantiated = Instantiate(explanationPrefab, pretestContent.transform.position, Quaternion.identity);

			questionToBeInstantiated.transform.parent = pretestContent.transform;
			explanationToBeInstantiated.transform.parent = pretestContent.transform;

			Text questionText = questionToBeInstantiated.GetComponent<Text>();
			questionText.text = GameInformation.PreQuestions[i].QuestionText;
			Text explanationText = explanationToBeInstantiated.GetComponentInChildren<Text>();
			explanationText.text = GameInformation.PreQuestions[i].Explanation;	
		}

		for (int i = 0; i < GameInformation.PostQuestions.Count; i++) 
		{
			GameObject questionToBeInstantiated = Instantiate(questionPrefab, posttestConent.transform.position, Quaternion.identity);
			GameObject explanationToBeInstantiated = Instantiate(explanationPrefab, posttestConent.transform.position, Quaternion.identity);

			questionToBeInstantiated.transform.parent = posttestConent.transform;
			explanationToBeInstantiated.transform.parent = posttestConent.transform;

			Text questionText = questionToBeInstantiated.GetComponent<Text>();
			questionText.text = GameInformation.PostQuestions[i].QuestionText;
			Text explanationText = explanationToBeInstantiated.GetComponentInChildren<Text>();
			explanationText.text = GameInformation.PostQuestions[i].Explanation;	
		}

		preScore.text += (numPreQuestions - GameInformation.PreQuestions.Count).ToString() + "/" + numPreQuestions.ToString();
		postScore.text += (numPostQuestions - GameInformation.PostQuestions.Count).ToString() + "/" + numPostQuestions.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
