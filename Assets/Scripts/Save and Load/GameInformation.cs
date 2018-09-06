using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameInformation : MonoBehaviour 
{

	private static List<PreQuestion> _preQuestions = new List<PreQuestion>();
	private static List<PostQuestion> _postQuestions = new List<PostQuestion>();

	public static List<PreQuestion> PreQuestions
	{
		get { return _preQuestions; }
		set { _preQuestions = value; }
	}

	public static List<PostQuestion> PostQuestions
	{
		get { return _postQuestions; }
		set { _postQuestions = value; }
	}

	void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
