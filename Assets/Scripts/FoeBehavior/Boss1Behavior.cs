using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Behavior : FoeMovement
{
    void Start()
    {
        StartCoroutine(UpdateCoroutine());
    }

    IEnumerator UpdateCoroutine()
    {
        while(true)
        {
            behavior = Behaviors.FollowPlayer;
            speedScale = 1f;
            yield return new WaitForSeconds(10);
            behavior = Behaviors.GoOriginPoint;
            speedScale = 2.5f;
            yield return new WaitForSeconds(5);
        }
    }
}
