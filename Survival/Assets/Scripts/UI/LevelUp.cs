using UnityEngine;

public class LevelUp : MonoBehaviour
{
    RectTransform rect;
    Player player;
    Item[] items;
    public const int ItemSpaceCount = 3;
    public int weaponCount = 5;
    public int itemCount = 8;
    bool startSet = true;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        items = GetComponentsInChildren <Item>(true);
    }

    private void Start()
    {
        player = GameManager.Instance.Player;
        if(player != null)
        {
            player.onLevelUp += Show;
        }
    }

    public void Show()
    {
        SelectItem();
        rect.localScale = Vector3.one;
        GameManager.Instance.Stop();
    }

    public void Hide()
    {
        rect.localScale = Vector3.zero;
        GameManager.Instance.Resume();
    }

    void SelectItem()
    {
        foreach(Item item in items)
        {
            item.gameObject.SetActive(false);
        }

        int[] randomItems = new int[ItemSpaceCount];
        int length = items.Length;
        while(true)
        {
            if (startSet)
            {
                length = weaponCount;
                startSet = false;
            }

            for(int i = 0; i < ItemSpaceCount; i++)
            {
                randomItems[i] = Random.Range(0, length);
            }


            if (DuplicationCheck(randomItems))
                break;
        }

        for(int i = 0; i < ItemSpaceCount; i++)
        {
            Item randomItem = items[randomItems[i]];

            if(randomItem.level == items[randomItems[i]].data.maxLevel)
            {
                items[itemCount-1].gameObject.SetActive(true);
            }
            else
            {
                randomItem.gameObject.SetActive(true);
            }
        }
    }

    bool DuplicationCheck(int[] items)
    {
        for(int i = 0; i < ItemSpaceCount; i++)
        {
            for(int j = 0; j <= i; j++)
            {
                if (i != j && items[i] == items[j])
                    return false;
            }
        }
        return true;
    }
}
