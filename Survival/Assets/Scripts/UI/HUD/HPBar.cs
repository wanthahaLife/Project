using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : HUD
{
    Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    protected override void HUDAction()
    {
        player.takeDamage += HPGuage;
    }

    void HPGuage()
    {
        slider.value = player.HP / player.MaxHP;
    }

}
