using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelText : HUD
{
    TextMeshProUGUI textMP;

    private void Awake()
    {
        textMP = GetComponent<TextMeshProUGUI>();
    }

    protected override void HUDAction()
    {
        player.onLevelUp += LevelUp;
    }

    void LevelUp()
    {
        textMP.text = $"Lv.{player.Level:F0}";
    }
}
