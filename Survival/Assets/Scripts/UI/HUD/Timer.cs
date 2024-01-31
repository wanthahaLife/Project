using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : HUD
{
    TextMeshProUGUI textMP;
    float gameTime = 0;
    const float OneMinute = 60.0f;
    private void Awake()
    {
        textMP = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        gameTime += Time.deltaTime;
        int min = Mathf.FloorToInt(gameTime / OneMinute);
        int sec = Mathf.FloorToInt(gameTime % OneMinute);
        textMP.text = $"{min:D2}:{sec:D2}";
        if (gameTime > 600.0f)
            GameOver();
    }

    void GameOver()
    {
        SceneChanger sceneChanger = new SceneChanger();
        sceneChanger.OverMenu();
    }
}
