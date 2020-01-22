using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeMovement : MonoBehaviour
{
    public enum Behaviors {Standby, FollowPlayer, FollowPlayerFar, GoOriginPoint};

    public Behaviors behavior;
    public float speedScale = 1;

    protected Player player;
    readonly Vector3 originPoint = new Vector3(0, 3, 10);


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        StartCoroutine(PositionUpdate());
    }
    
    protected IEnumerator PositionUpdate()
    {
        yield return 0;
        while(true)
        {
            if(!player)
                player = Player.instance;

            Vector3 shouldMove = Vector3.zero;   
            switch(behavior)
            {
                case Behaviors.Standby:
                    break;
                case Behaviors.FollowPlayer:
                    shouldMove = GotoPoint(player.transform.localPosition, 1f);
                    break;
                case Behaviors.FollowPlayerFar:
                    shouldMove = GotoPoint(player.transform.localPosition, 2.5f);
                    break;
                case Behaviors.GoOriginPoint:
                    shouldMove = GotoPoint(originPoint);
                    break;
            }
            shouldMove *= speedScale;
            transform.Translate(shouldMove);   
            yield return 0;
        }     
    }

    /// <summary>
    /// MoveToward - current pos == (移動距離)
    /// </summary>
    /// <param name="targetWorldPos"></param>
    /// <returns></returns>
    Vector3 GotoPoint(Vector3 targetLocalPos, float minDist = 0)
    {
        //Debug.Log($"MyPos={transform.localPosition} | TargetrPos={targetLocalPos}");
        if(minDist > 0)
        if(Vector3.Distance(transform.localPosition, targetLocalPos) < minDist)
            return Vector3.zero;

        Vector3 r = Vector3.MoveTowards(transform.localPosition, targetLocalPos, 1f * Time.deltaTime);
        r -= transform.localPosition;
        return r;
    }
}
