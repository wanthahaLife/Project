using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    RectTransform rect;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        Vector3 pos = GameManager.Instance.Player.transform.position;
        rect.position = Camera.main.WorldToScreenPoint(pos);
    }
}
