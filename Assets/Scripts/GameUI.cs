﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static Foe boss;
    [SerializeField] Text maxScoreLab;
    [SerializeField] Text scoreLab;
    [SerializeField] Text hpLab;
    [SerializeField] Text bombLab;
    [SerializeField] Text powerLab;
    [SerializeField] Text timeLab;

    [SerializeField] CanvasGroup bossBarArea;
    [SerializeField] Slider bossBar;
    [SerializeField] Text bossHPLab;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;
        bossBarArea.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        maxScoreLab.text = 0.ToString("000000000");
        scoreLab.text = player.score.ToString("000000000");
        hpLab.text = player.hp.ToString("0");
        bombLab.text = player.bombCount.ToString("0");
        powerLab.text = player.atk.ToString("0");
        timeLab.text = player.liveTime.ToString("0.0") + "s";

        if(isBossAlive())
        {
            if(bossBarArea.alpha < 1)
                bossBarArea.alpha += 1f * Time.deltaTime;

            bossHPLab.text = boss.hp.ToString("0");
            bossBar.value = (boss.hp / boss.hpmax);
        }
        else
        {
            if(bossBarArea.alpha > 0)
                bossBarArea.alpha -= 0.6f * Time.deltaTime;
        }
    }

    public static bool isBossAlive()
    {
        if(boss && boss.enabled)
            return true;
        else
            return false;
    }
}
