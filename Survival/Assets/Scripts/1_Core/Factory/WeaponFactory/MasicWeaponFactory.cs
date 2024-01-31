using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasicWeaponFactory : Singleton<MasicWeaponFactory>
{
    MagicCommonPool common;
    MagicUncommonPool uncommon;
    MagicMeleePool melee;
    MagicUncommonBurstPool uncommonBurst;
    // MagicMeleeBurstPool meleeBurst;

    /// <summary>
    /// 씬이 로딩 완료될 때마다 실행되는 초기화 함수
    /// </summary>
    protected override void OnInitialize()
    {
        base.OnInitialize();
        common = GetComponentInChildren<MagicCommonPool>();
        if (common != null)
        {
            common.Initialize();
        }
        uncommon = GetComponentInChildren<MagicUncommonPool>();
        if (uncommon != null)
        {
            uncommon.Initialize();
        }

        melee = GetComponentInChildren<MagicMeleePool>();
        if (melee != null)
        {
            melee.Initialize();
        }

        uncommonBurst = GetComponentInChildren<MagicUncommonBurstPool>();
        if (uncommonBurst != null)
        {
            uncommonBurst.Initialize();
        }
        /*meleeBurst = GetComponentInChildren<MagicMeleeBurstPool>();
        if (meleeBurst != null)
        {
            meleeBurst.Initialize();
        }*/

    }

    public Weapon GetWeapon(WeaponLevel type = WeaponLevel.Common, Vector3? position = null, Vector3? euler = null)
    {
        Weapon result = null;
        switch (type)
        {
            case WeaponLevel.Common:
                result = common.GetObject(position, euler);
                break;
            case WeaponLevel.Uncommon:
                result = uncommon.GetObject(position, euler);
                break;
            case WeaponLevel.Rare:
                break;
            case WeaponLevel.Melee:
                result = melee.GetObject(position, euler);
                break;
            case WeaponLevel.Lv4:
                break;
            case WeaponLevel.UncommonBurst:
                result = uncommonBurst.GetObject(position, euler);
                break;
                /*case WeaponLevel.MeleeBurst:
                    result = meleeBurst.GetObject(position, euler).gameObject;
                    break;*/
        }
        return result;
    }

    public MagicCommonWeapon GetCommon(Vector3? position = null, Vector3? euler = null)
    {
        return common.GetObject(position, euler);
    }
    public MagicUncommonWeapon GetUncommon(Vector3? position = null, Vector3? euler = null)
    {
        return uncommon.GetObject(position, euler);
    }
    public MagicMeleeWeapon GetMelee(Vector3? position = null, Vector3? euler = null)
    {
        return melee.GetObject(position, euler);
    }
    public MagicUncommonBurst GetUncommonBurst(Vector3? position = null, Vector3? euler = null)
    {
        return uncommonBurst.GetObject(position, euler);
    }
    /*public MagicMeleeBurst GetMeleeBurst(Vector3? position = null, Vector3? euler = null)
    {
        return meleeBurst.GetObject(position, euler);
    }*/
}
