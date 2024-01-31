using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : HUD
{
    Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    protected override void HUDAction()
    {
        player.killMonster += ExpGuage;
    }

    void ExpGuage()
    {
        slider.value = player.CurrExp / player.MaxExp;
    }

}
