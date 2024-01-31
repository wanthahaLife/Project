using UnityEngine;

public class LevelUp : MonoBehaviour
{
    RectTransform rect;
    Player player;
    Item[] items;
    public const int ItemSpaceCount = 3;
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
                length = 4;

            for(int i = 0; i < ItemSpaceCount; i++)
            {
                randomItems[i] = Random.Range(0, length);
            }


            if (randomItems[0] != randomItems[1] && randomItems[1] != randomItems[2] && randomItems[0] != randomItems[2])
                break;
        }

        for(int i = 0; i < randomItems.Length; i++)
        {
            Item randomItem = items[randomItems[i]];

            if(randomItem.level == randomItem.data.damages.Length)
            {
                items[7].gameObject.SetActive(true);
            }
            else
            {
                randomItem.gameObject.SetActive(true);
            }
        }
    }
}
