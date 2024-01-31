using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalMeleeGenerator : WeaponGeneraterBase
{
    Vector3 flipVec = Vector3.zero;
    private void Awake()
    {
        flipVec = new Vector3(0, 180, 0);
    }
    protected override void Generator(WeaponLevel weaponLevel = WeaponLevel.Common, Vector3? position = null, Vector3? euler = null)
    {
        if (transform.parent.localPosition.x > 0)
        {
            base.Generator(level, transform.position, flipVec);
        }
        else
        {
            base.Generator(level, transform.position, euler);
        }
    }
}
