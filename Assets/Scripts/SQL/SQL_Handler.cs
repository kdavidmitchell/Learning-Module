using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SQL_Handler : MonoBehaviour
{
    private string secretKey = "avocadotoast"; 
    public string postDataURL = "https://dyslexia-learning-module.000webhostapp.com/postdata.php";
    public string getDataURL = "https://dyslexia-learning-module.000webhostapp.com/getdata.php";
    
    //We start by just getting the HighScores, this should be removed, when you are done setting up.
    void Start()
    {
    	PostRandomData();
        StartCoroutine(GetData());
    }
    // This is for debugging purposes, you can run this when clicking
    // on a button, to see that scores are added. Remove when done setting up.
    public void PostRandomData()
    {
        int randomCorrect = (int)Random.RandomRange(0.0f, 32.0f);
        int randomIncorrect = 32 - randomCorrect;
        PostData(0, randomCorrect, randomIncorrect);
    }
    // This is for debugging purposes, you can run this when clicking on 
    // a button, to see the highscores that have been added. Remove when done setting up.
    public void GetTheScores()
    {
        StartCoroutine(GetData());
    }
    //This is where we post 
    public void PostData(int id, int correct, int incorrect)
    {
        string hash = Md5Sum(id + correct + incorrect + secretKey);
        WWWForm form = new WWWForm();
        form.AddField("idPost", id);
        form.AddField("correctPost", correct);
        form.AddField("incorrectPost", incorrect);
        form.AddField("hashPost", hash);
        WWW www = new WWW(postDataURL, form);
    }
    //This co-rutine gets the score, and print it to a text UI element.
    IEnumerator GetData()
    {
        WWW wwwwData = new WWW(getDataURL);
        yield return wwwwData;
        if (wwwwData.error != null)
        {
            print("There was an error getting the high score: " + wwwwData.error);
        }
        else
        {
            Debug.Log(wwwwData.text);
        }
    }
    // This is used to create a md5sum - so that we are sure that only legit scores are submitted.
    // We use this when we post the scores.
    // This should probably be placed in a seperate class. But isplaced here to make it simple to understand.
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
