using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SQL_Handler : MonoBehaviour
{
    private string secretKey = "avocadotoast";

    public string postPreTestDataURL = "https://dyslexia-learning-module.000webhostapp.com/postpretestdata.php";
    public string postPostTestDataURL = "https://dyslexia-learning-module.000webhostapp.com/postposttestdata.php";
    public string postSurveyDataURL = "https://dyslexia-learning-module.000webhostapp.com/postsurveydata.php";
    public string postTeacherDataURL = "https://dyslexia-learning-module.000webhostapp.com/postteacherdata.php";
    
    public string getDataURL = "https://dyslexia-learning-module.000webhostapp.com/getpretestdata.php";
    
    void Start()
    {
    	//GameInformation.TotalCompletionTime = Time.time;
    	//SaveInformation.SaveAllInformation();
    	//SendSurveyData();
    	SendTeacherData();
    }

    public void SendSurveyData()
    {
    	StartCoroutine(PostSurveyData());
    }

     public void SendTeacherData()
    {
    	StartCoroutine(PostTeacherData());
    }

    IEnumerator GetData()
    {
    	Debug.Log("Getting data...");
        WWW wwwGet = new WWW(getDataURL);
        yield return wwwGet;

        if (wwwGet.error != null)
        {
            print("There was an error getting the data: " + wwwGet.error);
        }
        else
        {
            Debug.Log(wwwGet.text);
        }
    }

    IEnumerator PostPreTestData()
    {

    	WWWForm form = new WWWForm();

    	int correct = GameInformation.CorrectPreQuestions.Count;
    	int incorrect = GameInformation.PreQuestions.Count;
    	int time = (int)GameInformation.PreCompletionTime;

    	string str = correct.ToString() + incorrect.ToString() + secretKey;
        string hash = Md5Sum(str);
        Debug.Log(hash);

    	form.AddField("correctPost", correct);
        form.AddField("incorrectPost", incorrect);
        form.AddField("timePost", time);
        form.AddField("hashPost", hash);

    	for (int i = 0; i < GameInformation.PreOrder.Count; i++) 
    	{
    		form.AddField("q" + i.ToString() + "IDPost", GameInformation.PreOrder[i].ID);

    		for (int j = 0; j < GameInformation.CorrectPreQuestions.Count; j++) 
    		{
    			if (GameInformation.CorrectPreQuestions[j].ID == GameInformation.PreOrder[i].ID)
    			{
    				Debug.Log("Question " + GameInformation.CorrectPreQuestions[j].ID.ToString() + " is correct");
    				form.AddField("q" + i.ToString() + "CorrectPost", 1);
    			}
    		}

    		for (int j = 0; j < GameInformation.PreQuestions.Count; j++) 
    		{
    			if (GameInformation.PreQuestions[j].ID == GameInformation.PreOrder[i].ID)
    			{
    				Debug.Log("Question " + GameInformation.PreQuestions[j].ID.ToString() + " is incorrect");
    				form.AddField("q" + i.ToString() + "CorrectPost", 0);
    			}
    		}
    	}

    	for (int i = 0; i < GameInformation.PreCertainty.Length; i++) 
    	{
    		form.AddField("q" + i.ToString() + "CertaintyPost", GameInformation.PreCertainty[i]);
    	}

    	WWW wwwPost = new WWW(postPreTestDataURL, form);
        yield return wwwPost;

        if (wwwPost.error != null)
        {
            print("There was an error getting the data: " + wwwPost.error);
        }
        else
        {
            Debug.Log(wwwPost.text);
        }
    }

    IEnumerator PostPostTestData()
    {

    	WWWForm form = new WWWForm();

    	int correct = GameInformation.CorrectPostQuestions.Count;
    	int incorrect = GameInformation.PostQuestions.Count;
    	int time = (int)GameInformation.PostCompletionTime;

    	string str = correct.ToString() + incorrect.ToString() + secretKey;
        string hash = Md5Sum(str);
        Debug.Log(hash);

    	form.AddField("correctPost", correct);
        form.AddField("incorrectPost", incorrect);
        form.AddField("timePost", time);
        form.AddField("hashPost", hash);

    	for (int i = 0; i < GameInformation.PostOrder.Count; i++) 
    	{
    		form.AddField("q" + i.ToString() + "IDPost", GameInformation.PostOrder[i].ID);

    		for (int j = 0; j < GameInformation.CorrectPostQuestions.Count; j++) 
    		{
    			if (GameInformation.CorrectPostQuestions[j].ID == GameInformation.PostOrder[i].ID)
    			{
    				Debug.Log("Question " + GameInformation.CorrectPostQuestions[j].ID.ToString() + " is correct");
    				form.AddField("q" + i.ToString() + "CorrectPost", 1);
    			}
    		}

    		for (int j = 0; j < GameInformation.PostQuestions.Count; j++) 
    		{
    			if (GameInformation.PostQuestions[j].ID == GameInformation.PostOrder[i].ID)
    			{
    				Debug.Log("Question " + GameInformation.PostQuestions[j].ID.ToString() + " is incorrect");
    				form.AddField("q" + i.ToString() + "CorrectPost", 0);
    			}
    		}
    	}

    	for (int i = 0; i < GameInformation.PostCertainty.Length; i++) 
    	{
    		form.AddField("q" + i.ToString() + "CertaintyPost", GameInformation.PostCertainty[i]);
    	}

    	WWW wwwPost = new WWW(postPostTestDataURL, form);
        yield return wwwPost;

        if (wwwPost.error != null)
        {
            print("There was an error getting the data: " + wwwPost.error);
        }
        else
        {
            Debug.Log(wwwPost.text);
        }
    }

    IEnumerator PostSurveyData()
    {
    	WWWForm form = new WWWForm();

        string hash = Md5Sum(secretKey);
        Debug.Log(hash);

        form.AddField("hashPost", hash);

        for (int i = 0; i < GameInformation.SurveyQuestions.Count; i++) 
        {
        	string concat = "";

        	foreach (string str in GameInformation.SurveyQuestions[i])
        	{
        		concat += str;
        		concat += "\n";
        	}

        	form.AddField("q" + i.ToString() + "SurveyPost", concat);
        }

        WWW wwwPost = new WWW(postSurveyDataURL, form);
        yield return wwwPost;

        if (wwwPost.error != null)
        {
            print("There was an error getting the data: " + wwwPost.error);
        }
        else
        {
            Debug.Log(wwwPost.text);
        }
    }

    IEnumerator PostTeacherData()
    {
    	WWWForm form = new WWWForm();

        string hash = Md5Sum(secretKey);
        Debug.Log(hash);

        form.AddField("hashPost", hash);

        for (int i = 0; i < GameInformation.TeacherQuestions.Count; i++) 
        {
        	string concat = "";

        	foreach (string str in GameInformation.TeacherQuestions[i])
        	{
        		concat += str;
        		concat += "\n";
        	}

        	form.AddField("q" + i.ToString() + "TeacherPost", concat);
        }

        WWW wwwPost = new WWW(postTeacherDataURL, form);
        yield return wwwPost;

        if (wwwPost.error != null)
        {
            print("There was an error getting the data: " + wwwPost.error);
        }
        else
        {
            Debug.Log(wwwPost.text);
        }
    }

    public string Md5Sum(string strToEncrypt)
    {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);
        // encrypt bytes
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);
        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";
        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }
        return hashString.PadLeft(32, '0');
    }
}
