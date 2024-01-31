using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillText : HUD
{
    TextMeshProUGUI textMP;

    private void Awake()
    {
        textMP = GetComponent<TextMeshProUGUI>();
    }

    protected override void HUDAction()
    {
        player.killMonster += OnKillUp;
    }

    void OnKillUp()
    {
        textMP.text = $"{player.KillCount:F0}";
    }
}
