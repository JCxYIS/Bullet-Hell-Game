using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
    public static int continueTime = 0;
    [SerializeField]Image image;
    [SerializeField]Text[] butts;

    public static void GameOver()
    {
         GameObject r = Resources.Load("Prefabs/GameOverScreen") as GameObject;
         GameObject g = Instantiate(r);
         Time.timeScale = 0;
         LoseScreen l = g.GetComponent<LoseScreen>();
         l.StartCoroutine(l.ShowGameOver());
    }

    public IEnumerator ShowGameOver()
    {    
        Color textOriColor = butts[0].color;
        foreach (var t in butts)
        {
            t.color = Color.clear;
        }
        for(float i = 0; i < 222f/255f; i+=0.005f)
        {
            image.color = new Color(1,1,1,i);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        foreach (var t in butts)
        {
            t.color = textOriColor;
        }
    }

    public void Retry()
    {
        GameFlowManager.Restart();
    }

    public void Continue()
    {
        Player.instance.hp = 3;
        Player.instance.score *= 0.75f;
        Time.timeScale = 1;
        continueTime++;
        Destroy(gameObject);
    }
}
