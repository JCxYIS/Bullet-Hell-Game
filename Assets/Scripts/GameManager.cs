using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Transform createFoeIn;
    [SerializeField] Animator stageShow;
    [SerializeField] GameObject winShow;
    public float time;



    void Start()
    {
        instance = this;
        winShow.SetActive(false);
        StartCoroutine(UpdateCoroutine());
    }
    void Update()
    {
        time += Time.deltaTime;
    }

    IEnumerator UpdateCoroutine()
    {
        Foe.foes.Clear();

        ShowStage(1);
        yield return new WaitForSeconds(2);
        for(int i = 0; i < 5; i++)
        {
            GameObject g = MakeFoe("Foe1");
            g.transform.Translate( (i%2==0)?-5:0, 0, 0);
            yield return new WaitForSeconds(2f);
        }
        for(int i = 0; i < 10; i++)
        {
            GameObject g = MakeFoe("Foe1");
            g.transform.Translate( (i%2==0)?-5:5, 0, 0);
            yield return new WaitForSeconds(1.5f);
        }
        yield return new WaitForSeconds(3);


        ShowStage(2);
        yield return new WaitForSeconds(2);
        MakeFoe("Boss1");
        yield return new WaitForSeconds(3);
        while(GameUI.isBossAlive())
            yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(3f);


        ShowStage(3);
        yield return new WaitForSeconds(2);
        for(int i = 0; i < 10; i++)
        {
            GameObject g = MakeFoe("Foe1");
            g.transform.Translate( (i%2==0)?-7:7, 0, 0);
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(3f);


        ShowStage(4);
        yield return new WaitForSeconds(2);
        MakeFoe("Boss2");
        yield return new WaitForSeconds(3);
        while(GameUI.isBossAlive())
            yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(3f);


        ShowStage(5);
        yield return new WaitForSeconds(2);
        MakeFoe("Group3");
        yield return new WaitForSeconds(10);
        MakeFoe("Group3");
        for(int i = 0; i < 5; i++)
        {
            GameObject g = MakeFoe("Foe1");
            g.transform.Translate( (i%2==0)?-7:7, 0, 0);
            yield return new WaitForSeconds(2f);
        }
        yield return new WaitForSeconds(7);


        ShowStage(6);
        yield return new WaitForSeconds(2);
        MakeFoe("Boss3");
        yield return new WaitForSeconds(3);
        while(GameUI.isBossAlive())
            yield return new WaitForSeconds(1);

        while(Foe.foes.Count > 0)
        {
            yield return new WaitForSeconds(1);
        }
        winShow.SetActive(true);
        Player.instance.isEnded = true;
        BulletHell.ProjectileManager.Instance.RefreshEmitters();
        if(!Player.instance.cheated)
            GetComponent<GameFlowManager>().RecordScore(Player.instance.score);
        Debug.Log("Clear!");
    }

    public GameObject MakeFoe(string nameInResource)
    {
        GameObject o = Resources.Load($"Foe/{nameInResource}") as GameObject;
        GameObject g = Instantiate(o, createFoeIn);
        return g;
    }

    void ShowStage(int stage)
    {
        stageShow.GetComponent<UnityEngine.UI.Text>().text = $"STAGE {stage}/6";
        stageShow.CrossFade("SHOW", 0, 0, 0);
    }
}
