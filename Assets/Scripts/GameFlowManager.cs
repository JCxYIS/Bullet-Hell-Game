using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    public static int hiScore;


    void Start()
    {
        hiScore = PlayerPrefs.GetInt("HISCORE", 0);
    }

    public void RecordScore(float newScore)
    {
        int ns = (int)newScore;
        if(ns > hiScore)
        {
            hiScore = ns;
            PlayerPrefs.SetInt("HISCORE", ns);
        }
    }

    public static void Restart()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.Save();
    }

}
