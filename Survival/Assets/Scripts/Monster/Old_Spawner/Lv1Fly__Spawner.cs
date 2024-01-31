using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv1Fly__Spawner : MonsterSpawner
{

    private void Awake()
    {
        level = 0;
        monsterType = MonsterType.FlyingMonster;
    }
}
