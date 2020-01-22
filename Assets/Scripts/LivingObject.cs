using UnityEngine;

public class LivingObject : MonoBehaviour 
{
    public float hp;
    public float atk;
    public float liveTime;


    void Start()
    {
        liveTime = 0;
    }

    void Update()
    {
        liveTime += Time.deltaTime;
    }

    public virtual void GetHurt(float rawdmg)
    {
        Debug.Log("NotImplement: LivingObj Get hurt");
    }
}