using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : RecycleObject
{
    [Header("공통 데이터")]
    public float damage = 1.0f;
    public float Damage
    {
        get => damage;
        set => damage = value;
    } 
    public float range = 1.0f;
    public float Range => range;

    [Header("무기 기본 데이터")]
    public float moveSpeed = 3.0f;
    public float MoveSpeed => moveSpeed;
    public int penetration = 0;
    public int Penetration => penetration;
    public bool isGuided = true;

    [Header("폭발 기본 데이터")]
    public float duration = 0.0f;

    public abstract void Init(ItemData data);
}
