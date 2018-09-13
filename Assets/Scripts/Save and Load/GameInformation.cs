using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameInformation : MonoBehaviour 
{

	private static List<PreQuestion> _preQuestions = new List<PreQuestion>();
	private static List<PostQuestion> _postQuestions = new List<PostQuestion>();
	private static int[] _preCertainty = new int[2];
	private static int[] _postCertainty = new int[2];
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

	public static int[] PreCertainty
	{
		get { return _preCertainty; }
		set { _preCertainty = value; }
	}

	public static int[] PostCertainty
	{
		get { return _postCertainty; }
		set { _postCertainty = value; }
	}

	void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
