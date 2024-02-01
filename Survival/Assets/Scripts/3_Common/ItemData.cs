using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object/ItemData")]
public class ItemData : ScriptableObject
{
    public enum ItemType
    {
        ElementalMelee,
        MagicCommon,
        MagicMelee,
        MagicUncommon,
        PhysicalMelee,
        Cross,
        Pigeon,
        Heal
    }

    [Header("Main Info")]
    public ItemType itemType;
    public string itemName;
    [TextArea]
    public string itemDesc;
    public Sprite itemIcon;
    public WeaponType weaponType;
    public WeaponLevel weaponLevel;
    public int maxLevel = 10;


    [Header("Weapon Data")]
    public float baseDamage;
    public float damageIncrease;
    public float baseRange;
    public float rangeIncrease;
    public int baseCount;
    public int countIncrease;
    public float baseSpeed;
    public float speedIncrease;
    public float BaseFireRate;
    public float FireRateDecrease;
    public float baseDuration;
    public float DuraionIncrease;
    public int basePenetration;
    public int penetrationIncrease;

    [Header("Weapon")]
    public GameObject projectile;
}
