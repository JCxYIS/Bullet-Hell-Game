using UnityEngine;

public class Foe: LivingObject
{
    public bool isBoss;
    public float hpmax;

    Player player;


    void Start()
    {
        if(isBoss)
            GameUI.boss = this;

        hp = hpmax;
        player = Player.instance;
    }
    void Update()
    {
        if(hp < 0)
        {
            hp = 0;

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