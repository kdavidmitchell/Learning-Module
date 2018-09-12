using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameInformation : MonoBehaviour 
{

	private static List<PreQuestion> _preQuestions = new List<PreQuestion>();
	private static List<PostQuestion> _postQuestions = new List<PostQuestion>();
	private static bool _TPJComplete = false;
	private static bool _allAreasComplete = false;

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

	public static bool TPJComplete
	{
		get { return _TPJComplete; }
		set { _TPJComplete = value; }
	}

	public static bool AllAreasComplete
	{
		get { return _allAreasComplete; }
		set { _allAreasComplete = value; }
	}

	void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
