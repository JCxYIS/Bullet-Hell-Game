using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Transform createFoeIn;
    public float time;



    void Start()
    {
        instance = this;
        StartCoroutine(UpdateCoroutine());
    }
    void Update()
    {
        time += Time.deltaTime;
    }

    IEnumerator UpdateCoroutine()
    {
        yield return new WaitForSeconds(1);

        Debug.Log("STAGE 1");
        for(int i = 0; i < 5; i++)
        {
            GameObject g = MakeFoe("Foe1");
            g.transform.Translate( (i%2==0)?-5:0, 0, 0);
            yield return new WaitForSeconds(1.5f);
        }
        for(int i = 0; i < 10; i++)
        {
            GameObject g = MakeFoe("Foe1");
            g.transform.Translate( (i%2==0)?-5:5, 0, 0);
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(3);


        Debug.Log("STAGE 2");
        MakeFoe("Boss1");
        yield return new WaitForSeconds(3);
        while(GameUI.isBossAlive())
            yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(3f);


        Debug.Log("STAGE 3");
        for(int i = 0; i < 15; i++)
        {
            GameObject g = MakeFoe("Foe1");
            g.transform.Translate( (i%2==0)?-7:7, 0, 0);
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(3f);


        Debug.Log("STAGE 4");
        MakeFoe("Boss2");
        yield return new WaitForSeconds(3);
        while(GameUI.isBossAlive())
            yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(3f);


        Debug.Log("STAGE 5");
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


        Debug.Log("STAGE 6");
        MakeFoe("Boss3");
        yield return new WaitForSeconds(3);
        while(GameUI.isBossAlive())
            yield return new WaitForSeconds(1);

        Debug.Log("Clear!");
    }

    public GameObject MakeFoe(string nameInResource)
    {
        GameObject o = Resources.Load($"Foe/{nameInResource}") as GameObject;
        GameObject g = Instantiate(o, createFoeIn);
        return g;
    }
}
