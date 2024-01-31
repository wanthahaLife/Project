using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    protected Player player;

    private void Start()
    {
        player = GameManager.Instance.Player;
        if (player != null)
        {
            HUDAction();
        }
    }

    protected virtual void HUDAction()
    {
    }
}
