using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv1Fly_ : MonsterBase
{
    private Vector2 startDir = Vector2.right;
    protected override void OnEnable()
    {
        base.OnEnable();
        startDir = (Vector2)player.transform.position - rigid.position;
    }

    protected override void MoveMonster()
    {
        rigid.MovePosition(rigid.position + (Vector2)(moveSpeed * Time.fixedDeltaTime * startDir.normalized));
    }

    protected override void Reposition()
    {
    }
}
