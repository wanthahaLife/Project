using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType
{
    BasicMonster = 0,
    FlyingMonster,
    BossMonster,
}

public class MonsterFactory : Singleton<MonsterFactory>
{
    MonsterPool[][] monsterPools;

    /// <summary>
    /// 씬이 로딩 완료될 때마다 실행되는 초기화 함수
    /// </summary>
    protected override void OnInitialize()
    {
        base.OnInitialize();
        monsterPools = new MonsterPool[transform.childCount][];
        for (int i = 0; i < transform.childCount; i++)
        {
            monsterPools[i] = transform.GetChild(i).GetComponentsInChildren<MonsterPool>();
            for (int j = 0; j < monsterPools[i].Length; j++)
            {
                monsterPools[i][j].Initialize();
            }
        }
    }

    public MonsterBase GetObject(MonsterType type = MonsterType.BasicMonster, int level = 0, Vector3? position = null, Vector3? euler = null)
    {
        return monsterPools[level][(int)type].GetObject(position, euler);
    }
}
