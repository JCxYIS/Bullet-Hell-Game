using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Behavior : FoeMovement
{
    void Start()
    {
        StartCoroutine(UpdateCoroutine());
    }

    IEnumerator UpdateCoroutine()
    {
        Foe f = GetComponent<Foe>();
        while(true)
        {
            f.hp += f.hpmax / 8f;
            speedScale += 0.25f;
            if(f.hp > f.hpmax)
                f.hp = f.hpmax;
            yield return new WaitForSeconds(9.99f);
        }
    }
}
