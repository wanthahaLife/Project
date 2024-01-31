using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicUncommonWeapon : WeaponBase
{
    protected override void CollisionAction()
    {
        BurstBase tmpBurst = MasicWeaponFactory.Instance.GetUncommonBurst(transform.position);
        tmpBurst.Damage = GetDamage();
    }
}
