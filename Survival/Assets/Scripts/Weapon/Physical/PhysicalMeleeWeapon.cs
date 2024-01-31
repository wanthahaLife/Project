using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PhysicalMeleeWeapon : WeaponBase
{
    float startFirePosX;

    protected override void OnEnable()
    {
        if(player == null)
        {
            player = GameManager.Instance.Player;
        }
        else
        {
            Transform firePosition = player.transform.GetChild(0);
            startFirePosX = firePosition.localPosition.x;
        }
        StartCoroutine(LifeOver());
    }



    protected override void MoveProjectile(float deltaTime, Vector3 direction)
    {
        Vector3 pos = player.transform.position;
        pos.x += startFirePosX;
        transform.position = pos;
    }

}
