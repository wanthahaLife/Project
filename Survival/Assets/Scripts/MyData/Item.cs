using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Item : MonoBehaviour
{
    public ItemData data;
    public int level;
    public ElementalMeleeGenerator elementalMelee;
    public MagicCommonGenerator magicCommon;
    public MagicMeleeGenerator magicMelee;
    public MagicUncommonGenerator magicUncommon;
    public PhysicalMeleeGenerator physicalMelee;

    Image icon;
    TextMeshProUGUI textLevel;
    TextMeshProUGUI textName;
    TextMeshProUGUI textDesc;


    Player player;
    Transform FlipPosition;
    Transform RotatePosition;
    Transform CenterPosition;

    private void Awake()
    {
        icon = GetComponentsInChildren<Image>()[1];
        icon.sprite = data.itemIcon;

        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();
        textLevel = texts[0];
        textName = texts[1];
        textDesc = texts[2];
        textName.text = data.itemName;
    }

    private void OnEnable()
    {
        textLevel.text = $"Lv. {level + 1}";
        //textDesc.text = string.Format(data.itemDesc);
    }

    private void Start()
    {
        player = GameManager.Instance.Player;
        if(player != null )
        {
            FlipPosition = player.transform.GetChild(0);
            RotatePosition = player.transform.GetChild(1);
            CenterPosition = player.transform.GetChild(2);
        }
    }

    public void OnClick()
    {
        switch (data.itemType)
        {
            case ItemData.ItemType.ElementalMelee:
                if(level == 0)
                {
                    GameObject newGenerator = new GameObject();
                    elementalMelee = newGenerator.AddComponent<ElementalMeleeGenerator>();
                    elementalMelee.Init(data, CenterPosition);
                }
                elementalMelee.LevelUp(level);
                break;
            case ItemData.ItemType.MagicCommon:
                if (level == 0)
                {
                    GameObject newGenerator = new GameObject();
                    magicCommon = newGenerator.AddComponent<MagicCommonGenerator>();
                    magicCommon.Init(data, FlipPosition);
                }
                break;
            case ItemData.ItemType.MagicMelee:
                if (level == 0)
                {
                    GameObject newGenerator = new GameObject();
                    magicMelee = newGenerator.AddComponent<MagicMeleeGenerator>();
                    magicMelee.Init(data, CenterPosition);
                }
                break;
            case ItemData.ItemType.MagicUncommon:
                if (level == 0)
                {
                    GameObject newGenerator = new GameObject();
                    magicUncommon = newGenerator.AddComponent<MagicUncommonGenerator>();
                    magicUncommon.Init(data, FlipPosition);
                }
                break;
            case ItemData.ItemType.PhysicalMelee:
                if (level == 0)
                {
                    GameObject newGenerator = new GameObject();
                    physicalMelee = newGenerator.AddComponent<PhysicalMeleeGenerator>();
                    physicalMelee.Init(data, FlipPosition);
                }
                break;
            case ItemData.ItemType.Cross:
                break;
            case ItemData.ItemType.Pigeon:
                break;
            case ItemData.ItemType.Heal: 
                break;

        }
        level++;

        if (level == data.maxLevel)
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
