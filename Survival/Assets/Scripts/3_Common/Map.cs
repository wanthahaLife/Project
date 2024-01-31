using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    Player player;
    const float TranslateSize = 72;       //36 * 2


    private void Start()
    {
        player = GameManager.Instance.Player;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerArea"))
        {
            Reposition();
        }
    }

    void Reposition()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 thisPos = transform.position;
        float diffX = playerPos.x - thisPos.x;
        float diffY = playerPos.y - thisPos.y;

        float dirX = diffX > 0 ? 1 : -1;
        float dirY = diffY > 0 ? 1 : -1;

        diffX = Mathf.Abs(diffX);
        diffY = Mathf.Abs(diffY);

        if (diffX > diffY)
        {
            transform.Translate(Vector3.right * dirX * TranslateSize);
        }
        else if (diffX < diffY)
        {
            transform.Translate(Vector3.up * dirY * TranslateSize);
        }
    }
}
