using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameInformation : MonoBehaviour 
{

	private static List<PreQuestion> _preQuestions = new List<PreQuestion>();
	private static List<PostQuestion> _postQuestions = new List<PostQuestion>();
	private static List<PreQuestion> _correctPreQuestions = new List<PreQuestion>();
	private static List<PostQuestion> _correctPostQuestions = new List<PostQuestion>();
	private static List<PreQuestion> _preOrder = new List<PreQuestion>();
	private static List<PostQuestion> _postOrder = new List<PostQuestion>();
	private static Dictionary<int, List<string>> _surveyQuestions = new Dictionary<int, List<string>>();
	private static Dictionary<int, List<string>> _teacherQuestions = new Dictionary<int, List<string>>();
	private static int[] _preCertainty = new int[32];
	private static int[] _postCertainty = new int[32];
	private static bool _TPJComplete = false;
	private static bool _OTComplete = false;
	private static bool _RHComplete = false;
	private static bool _IFGComplete = false;
	private static bool _allAreasComplete = false;
	private static bool _interventionComplete = false;
	private static float _preCompletionTime = 0f;
	private static float _postCompletionTime = 0f;
	private static float _totalCompletionTime = 0f;

	private static GameInformation instance = null;

	//Options
	private static bool _colorblindMode = false;
	private static bool _speechAutoPlay = false;

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

	public static List<PreQuestion> CorrectPreQuestions
	{
		get { return _correctPreQuestions; }
		set { _correctPreQuestions = value; }
	}

	public static List<PostQuestion> CorrectPostQuestions
	{
		get { return _correctPostQuestions; }
		set { _correctPostQuestions = value; }
	}

	public static List<PreQuestion> PreOrder
	{
		get { return _preOrder; }
		set { _preOrder = value; }
	}

	public static List<PostQuestion> PostOrder
	{
		get { return _postOrder; }
		set { _postOrder = value; }
	}

	public static Dictionary<int, List<string>> SurveyQuestions
	{
		get { return _surveyQuestions; }
		set { _surveyQuestions = value; }
	}

	public static Dictionary<int, List<string>> TeacherQuestions
	{
		get { return _teacherQuestions; }
		set { _teacherQuestions = value; }
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

	public static bool IFGComplete
	{
		get { return _IFGComplete; }
		set { _IFGComplete = value; }
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

	public static float PreCompletionTime 
	{
		get { return _preCompletionTime; }
		set { _preCompletionTime = value; }
	}

	public static float PostCompletionTime 
	{
		get { return _postCompletionTime; }
		set { _postCompletionTime = value; }
	}

	public static float TotalCompletionTime 
	{
		get { return _totalCompletionTime; }
		set { _totalCompletionTime = value; }
	}

	//Options

	public static bool ColorblindMode
	{
		get { return _colorblindMode; }
		set { _colorblindMode = value; }
	}

	public static bool SpeechAutoPlay
	{
		get { return _speechAutoPlay; }
		set { _speechAutoPlay = value; }
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
