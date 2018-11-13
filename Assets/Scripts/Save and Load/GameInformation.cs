using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameInformation : MonoBehaviour 
{

	private static List<PreQuestion> _preQuestions = new List<PreQuestion>();
	private static List<PostQuestion> _postQuestions = new List<PostQuestion>();
	private static List<PostQuestion> _correctPostQuestions = new List<PostQuestion>();
	private static int[] _preCertainty = new int[2];
	private static int[] _postCertainty = new int[32];
	private static bool _TPJComplete = false;
	private static bool _OTComplete = false;
	private static bool _RHComplete = false;
	private static bool _allAreasComplete = false;
	private static bool _interventionComplete = false;

	private static GameInformation instance = null;

	//Options
	private static bool _colorblindMode = false;

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

	public static List<PostQuestion> CorrectPostQuestions
	{
		get { return _correctPostQuestions; }
		set { _correctPostQuestions = value; }
	}

	public static bool TPJComplete
	{
		get { return _TPJComplete; }
		set { _TPJComplete = value; }
	}

	public static bool OTComplete
	{
		get { return _OTComplete; }
		set { _OTComplete = value; }
	}

	public static bool RHComplete
	{
		get { return _RHComplete; }
		set { _RHComplete = value; }
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

	public static bool InterventionComplete 
	{
		get { return _interventionComplete; }
		set { _interventionComplete = value; }
	}

	//Options

	public static bool ColorblindMode
	{
		get { return _colorblindMode; }
		set { _colorblindMode = value; }
	}

	void Awake()
    {
    	if (instance == null)
    	{
    		instance = this;
    		DontDestroyOnLoad(gameObject);
    	} else 
    	{
    		Destroy(gameObject);	
    	}
    }
}
