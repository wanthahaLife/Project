using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ElementalMeleeGenerator : WeaponGeneraterBase
{
    [Header("엘리멘탈 근접무기 데이터")]
    public float rotateSpeed = 30.0f;

    ElementalMeleeWeapon elementalMeleeWeapon;

    public override void Init(ItemData data, Transform parent)
    {
        base.Init(data, parent);
        projectileConunt = data.baseCount;
        rotateSpeed = data.baseSpeed;
    }

    public override void LevelUp(int level)
    {
        base.LevelUp(level);
        projectileConunt = data.baseCount + data.countIncrease * level;
        rotateSpeed = data.baseSpeed + data.speedIncrease * level;
    }
    protected override void Generator(WeaponLevel weaponLevel = WeaponLevel.Common, Vector3? position = null, Vector3? euler = null)
    {
        float angle = 360 / projectileConunt;
        for(int i = 0; i < projectileConunt; i++)
        {
            Vector3 rotateVec = Vector3.forward * i * angle;
            elementalMeleeWeapon = ElementalWeaponFactory.Instance.GetMelee(transform.position, rotateVec);
            elementalMeleeWeapon.transform.SetParent(transform);
            elementalMeleeWeapon.transform.Translate(elementalMeleeWeapon.transform.up * elementalMeleeWeapon.range, Space.World);
            elementalMeleeWeapon.Init(data);
        }
    }
    private void Update()
    {
        RotateWeapon();
    }

    private void RotateWeapon()
    {
        transform.Rotate(Time.deltaTime * -rotateSpeed * Vector3.forward);
    }
}
