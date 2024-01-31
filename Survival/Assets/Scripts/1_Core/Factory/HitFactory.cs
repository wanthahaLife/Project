using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HitType 
{
    BasicHit = 0,
}


public class HitFactory : Singleton<HitFactory>
{
    HitPool[] hitPool;

    /// <summary>
    /// 씬이 로딩 완료될 때마다 실행되는 초기화 함수
    /// </summary>
    protected override void OnInitialize()
    {
        base.OnInitialize();
        hitPool = GetComponentsInChildren<HitPool>();
        
    }
    public BurstBase GetObject(HitType type = HitType.BasicHit, Vector3? position = null, Vector3? euler = null)
    {
        return hitPool[(int)type].GetObject(position, euler);
    }
}
