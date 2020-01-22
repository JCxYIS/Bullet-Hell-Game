using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Behavior : FoeMovement
{
    Foe f;
    Player p;
    [SerializeField] BulletHell.ProjectileEmitterAdvanced ULTIMATEATTACK;

    void Start()
    {
        f = GetComponent<Foe>();
        p = Player.instance;
        StartCoroutine(NormalSkillCoroutine());
        StartCoroutine(UltimateSkillCoroutine());
    }

    IEnumerator NormalSkillCoroutine()
    {
        
        while(true)
        {
            yield return new WaitForSeconds(8.7f);
            p.bombCount++;
            p.atk++;
            GameManager.instance.MakeFoe("Foe1");
        }
    }

    IEnumerator UltimateSkillCoroutine()
    {
        ULTIMATEATTACK.enabled = false;
        while(true)
        {
            yield return new WaitForSeconds(27);
            ULTIMATEATTACK.enabled = true;
            GameManager.instance.MakeFoe("Group3");
            GameManager.instance.MakeFoe("Foe1");
            p.hp += 10f;
            p.atk += 10f;
            f.hp += 7777f;
            if(f.hp > f.hpmax)
                f.hp = f.hpmax;         
            yield return new WaitForSeconds(3);
            ULTIMATEATTACK.enabled = false;
        }
    }

}
