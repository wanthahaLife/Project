using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/ItemData")]
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


    [Header("Level Data")]
    public float baseDamage;
    public int baseCount;
    public float[] damages;
    public float[] counts;

    [Header("Weapon")]
    public GameObject projectile;
}
