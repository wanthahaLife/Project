using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalWeaponFactory : Singleton<PhysicalWeaponFactory>
{
    PhysicalMeleePool melee;

    /// <summary>
    /// 씬이 로딩 완료될 때마다 실행되는 초기화 함수
    /// </summary>
    protected override void OnInitialize()
    {
        base.OnInitialize();
        melee = GetComponentInChildren<PhysicalMeleePool>();
        if (melee != null)
        {
            melee.Initialize();
        }

    }

    public Weapon GetWeapon(WeaponLevel type = WeaponLevel.Common, Vector3? position = null, Vector3? euler = null)
    {
        Weapon result = null;
        switch (type)
        {
            case WeaponLevel.Common:
                break;
            case WeaponLevel.Uncommon:
                break;
            case WeaponLevel.Rare:
                break;
            case WeaponLevel.Lv3:
                break;
            case WeaponLevel.Lv4:
                break;
            case WeaponLevel.Lv5:
                break;
            case WeaponLevel.Melee:
                result = melee.GetObject(position, euler);
                break;
        }
        return result;
    }

    public PhysicalMeleeWeapon GetMelee(Vector3? position = null, Vector3? euler = null)
    {
        return melee.GetObject(position, euler);
    }
}
