using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : LivingObject
{
    public static Player instance;

    public float score;
    public float bombCount;

    [SerializeField] BulletHell.ProjectileEmitterAdvanced emittor;

    float invincibleTime;
    SpriteRenderer sprite;


    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        hp = 10;
        atk = 1;
    }

    // Update is called once per frame
    void Update()
    {
        InvincibleAnimation();
        ApplyPower();

        // cheat
        if(Input.GetKeyDown(KeyCode.F12))
        {
            hp++;
        }
        if(hp > 0 && Input.GetKeyDown(KeyCode.F11))
        {
            Time.timeScale = 0.2f;
        }
        else if(hp > 0 && Input.GetKeyUp(KeyCode.F11))
        {
            Time.timeScale = 1f;
        }
    }

    public override void GetHurt(float rawatk)
    {
        if(invincibleTime <= 0)
        {
            invincibleTime = 1.5f;
            hp -= 1;
        }
    }

    void InvincibleAnimation()
    {
        invincibleTime -= Time.deltaTime;
        if(invincibleTime > 0)
        {
            if( (invincibleTime*9f) % 2 >= 1)
                sprite.enabled = true;
            else
                sprite.enabled = false;
            
        }
        else
        {
            sprite.enabled = true;
        }
    }

    void ApplyPower()
    {
        int spikes = Mathf.CeilToInt(atk / 20);
        if(spikes > 10)
            spikes = 10;
        emittor.SpokeCount = spikes;
        emittor.atk = atk;
    }
}
