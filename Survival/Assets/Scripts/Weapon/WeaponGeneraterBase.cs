using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGeneraterBase : MonoBehaviour
{
    protected WaitForSeconds createWaitTime;
    protected WeaponBase weapon;
    protected ItemData data;
    
    [Header("발생기 기본 데이터")]
    public WeaponType type;
    public WeaponLevel level;
    public float cooltime = 1.0f;
    public int projectileConunt = 1;

    protected float Cooltime
    {
        get => cooltime;
        set
        {
            if (cooltime != value)
            {
                cooltime = value;
                createWaitTime = new WaitForSeconds(cooltime);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Cooltime = cooltime;
        createWaitTime = new WaitForSeconds(Cooltime);
    }

    public void Init(ItemData data, Transform parent)
    {
        transform.parent = parent;
        transform.localPosition = Vector3.zero;
        this.data = data;
        DataSet();
        StartCoroutine(GenerateStarter());
    }

    void DataSet()
    {
        name = "Generator: " + data.itemName;
        type = data.weaponType;
        level = data.weaponLevel;
        projectileConunt = data.baseCount;
    }

    IEnumerator GenerateStarter()
    {
        while (true)
        {
            Cooltime = cooltime;
            Generator(level, transform.position);
            yield return createWaitTime;
        }
    }

    protected virtual void Generator(WeaponLevel weaponLevel = WeaponLevel.Common, Vector3? position = null, Vector3? euler = null)
    {
        Weapon weapon = null;
        switch (type)
        {
            case WeaponType.Physical:
                weapon = PhysicalWeaponFactory.Instance.GetWeapon(weaponLevel, position, euler);
                break;
            case WeaponType.Magic:
                weapon = MasicWeaponFactory.Instance.GetWeapon(weaponLevel, position, euler);
                break;
            case WeaponType.Elemental:
                weapon = ElementalWeaponFactory.Instance.GetWeapon(weaponLevel, position, euler);
                break;
            case WeaponType.Science:
                break;
        }
        if (weapon != null)
        {
            weapon.Init(data);
        }
    }

    protected virtual void GenerateAdditionalAction()
    {

    }
}
