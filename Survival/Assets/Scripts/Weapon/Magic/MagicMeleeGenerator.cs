using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMeleeGenerator : WeaponGeneraterBase
{
    MagicMeleeWeapon magicMeleeWeapon;
    protected override void Generator(WeaponLevel weaponLevel = WeaponLevel.Common, Vector3? position = null, Vector3? euler = null)
    {
        magicMeleeWeapon = MasicWeaponFactory.Instance.GetMelee(transform.position);
        SetCooltime();
    }

    private void SetCooltime()
    {
        Cooltime = Mathf.Max(Cooltime, magicMeleeWeapon.LifeTime);
    }
}
