using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    Player player;
    public bool isPause = false;
    public Player Player
    {
        get
        {
            if(player == null)  // 초기화 전에 Player에 접근했을 경우
            {
                OnInitialize();
            }
            return player;
        }
    }

    protected override void OnInitialize()
    {
        base.OnInitialize();
        player = FindAnyObjectByType<Player>();
    }

    public void Stop()
    {
        isPause = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isPause = false;
        Time.timeScale = 1;
    }
}
