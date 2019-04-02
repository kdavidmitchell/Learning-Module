using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SQL_Handler : MonoBehaviour
{
    private string secretKey = "avocadotoast"; 
    public string postDataURL = "https://dyslexia-learning-module.000webhostapp.com/postpretestdata.php";
    public string getDataURL = "https://dyslexia-learning-module.000webhostapp.com/getpretestdata.php";
    
    void Start()
    {
    	//GameInformation.TotalCompletionTime = Time.time;
    	//SaveInformation.SaveAllInformation();
    	SendPreTestData();
    }
    
    public void PostRandomData()
    {
        int randomCorrect = (int)Random.RandomRange(0.0f, 32.0f);
        int randomIncorrect = 32 - randomCorrect;
        StartCoroutine(PostData(0, randomCorrect, randomIncorrect));
    }

    public void SendPreTestData()
    {
    	StartCoroutine(PostPreTestData());
    }

    //This is where we post 
    IEnumerator PostData(int id, int correct, int incorrect)
    {

    	string str = id.ToString() + correct.ToString() + incorrect.ToString() + secretKey;
        string hash = Md5Sum(str);
        Debug.Log(hash);

        WWWForm form = new WWWForm();
        form.AddField("idPost", id);
        form.AddField("correctPost", correct);
        form.AddField("incorrectPost", incorrect);
        form.AddField("hashPost", hash);

        WWW wwwPost = new WWW(postDataURL, form);
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

    	WWW wwwPost = new WWW(postDataURL, form);
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
