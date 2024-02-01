using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMeleeWeapon : WeaponBase
{
    //[Header("마법 근접 무기 데이터")]
    //public float flameGenTime = 0.5f;

    protected override void OnEnable()
    {
        base.OnEnable();

    }

    protected override void MoveProjectile(float deltaTime, Vector3 direction)
    {
        // 생성되고 플레이어 따라감
        transform.position = player.transform.position;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    /*protected override void AdditionalAction()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > flameGenTime)
        {
            Vector3 randomPoint = Random.insideUnitCircle * Random.Range(0, radius);
            MasicWeaponFactory.Instance.GetMeleeBurst(transform.position + randomPoint);
            elapsedTime = 0;
        }
    }*/
}
