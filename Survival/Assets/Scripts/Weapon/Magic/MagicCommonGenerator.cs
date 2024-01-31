using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCommonGenerator : WeaponGeneraterBase
{
    public float createRange = 1.0f;

    protected override void Generator(WeaponLevel weaponLevel = WeaponLevel.Common, Vector3? position = null, Vector3? euler = null)
    {
        float range = Random.Range(-createRange, createRange);
        Vector3 pos = transform.position;
        pos.y = transform.position.y + range;
        base.Generator(level, pos, null);
    }
}
