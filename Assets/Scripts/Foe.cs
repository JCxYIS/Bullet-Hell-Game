using UnityEngine;
using System.Collections.Generic;

public class Foe: LivingObject
{
    public static List<Foe> foes = new List<Foe>();
    public bool isBoss;
    public float hpmax;

    Player player;


    void Start()
    {
        foes.Add(this);
        if(isBoss)
            GameUI.boss = this;

        hp = hpmax;
        player = Player.instance;
    }
    void Update()
    {
        if(hp <= 0)
        {
            foes.Remove(this);

            transform.position = new Vector3(9999,9999,0);
            this.enabled = false;
            /*
            for(int i = 0; i < transform.childCount; i++)
            {
                var g = transform.GetChild(i).GetComponent<BulletHell.ProjectileEmitterAdvanced>();
                if(g)
                    g.enabled = false;
            } 
            */           
            Destroy(gameObject, 5);

            if(isBoss)
            {
                player.atk += 15;
                player.bombCount += 1;
            }
            else
                player.atk += 1;

            if(GetComponent<FoeMovement>())
                GetComponent<FoeMovement>().enabled = false;
            
        }
    }

    public override void GetHurt(float rawdmg)
    {
        hp -= rawdmg;
        player.score += rawdmg*10;
    }

}