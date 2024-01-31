using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv2__Spawner : MonsterSpawner
{
    private void Awake()
    {
        level = 1;
        monsterType = MonsterType.BasicMonster;
    }
}
