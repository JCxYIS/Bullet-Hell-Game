using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : LivingObject
{
    public static Player instance;

    public float score;
    public float bombCount;
    public bool cheated = false;
    [HideInInspector] public bool isEnded = false;

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
        bombCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isEnded)
        {
            liveTime += Time.deltaTime;
            InvincibleAnimation();
            ApplyPower();

            if(bombCount > 0 && Input.GetKeyDown(KeyCode.Space))
            {
                BulletHell.ProjectileManager.Instance.RefreshEmitters();
                bombCount--;
            }

            // cheat
            if(Input.GetKeyDown(KeyCode.F12))
            {
                hp++;
                cheated = true;
            }
            if(Input.GetKeyDown(KeyCode.F11))
            {
                bombCount++;
                cheated = true;
            }
            if(Input.GetKeyDown(KeyCode.F10))
            {
                atk++;
                cheated = true;
            }
            if(hp > 0 && Input.GetKeyDown(KeyCode.CapsLock))
            {
                Time.timeScale = 0.2f;
                cheated = true;
            }
            else if(hp > 0 && Input.GetKeyUp(KeyCode.CapsLock))
            {
                Time.timeScale = 1f;
            }
        }
    }

    public override void GetHurt(float rawatk)
    {
        if(invincibleTime <= 0)
        {
            invincibleTime = 1.5f;
            hp -= 1;

            if(hp <= 0)
            {
                LoseScreen.GameOver();
            }
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
