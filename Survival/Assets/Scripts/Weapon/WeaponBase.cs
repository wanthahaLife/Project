using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponBase : Weapon
{

    public float LifeTime
    {
        get => lifeTime;
        set
        {
            if(lifeTime != value)
            {
                lifeTime = value;
            }
        }
    }

    Vector3 direction = Vector3.zero;
    protected Vector3 Direction
    {
        get => direction;
        set => direction = value.normalized;
    }
    protected int currPenetration = 0;

    protected Player player;
    Rigidbody2D rigid;

    Vector3 rigidOriginRange;
    Vector3 transformOriginRange;
    Transform target;

    protected ItemData data;

    private void Awake()
    {
        if (TryGetComponent<Rigidbody2D>(out rigid))
            rigidOriginRange = rigid.transform.localScale;
        transformOriginRange = transform.localScale;
    }

    protected override void OnEnable()
    {
        if(player == null)
            player = GameManager.Instance.Player;
        currPenetration = 0;
        target = player.scanner.nearestTarget;
        GuidedProjectile();
        StartCoroutine(LifeOver());
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        if (rigid != null)
            rigid.transform.localScale = rigidOriginRange;
        transform.localScale = transformOriginRange;
    }

    public override void Init(ItemData data)
    {
        this.data = data;
        Damage = data.baseDamage;
        range = data.baseRange;
        moveSpeed = data.baseSpeed;
        penetration = data.basePenetration;
    }

    public override void LevelUp(int level)
    {
        Damage = data.baseDamage + data.damageIncrease * level;
        range = data.baseRange + data.rangeIncrease * level;
        moveSpeed = data.baseSpeed + data.speedIncrease * level;
        penetration = data.basePenetration + data.penetrationIncrease * level;
        RangeControl();
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            CollisionAction();
            if (penetration > -1)       // pernetration이 -1이면 무한관통
            {
                currPenetration++;
                if (currPenetration > penetration)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.isPause) return;
        MoveProjectile(Time.fixedDeltaTime, Direction);
        AdditionalAction();
    }

    protected virtual void RangeControl()
    {
        if (rigid != null)
        {
            rigid.transform.localScale *= range;
        }
        transform.localScale *= range;
    }
    protected virtual void MoveProjectile(float deltaTime, Vector3 direction)
    {
        //Debug.Log(direction);
        transform.Translate(deltaTime * moveSpeed * Vector3.left);
    }

    protected virtual void AdditionalAction()
    {
    }

    protected virtual void CollisionAction()
    {

    }

    private void GuidedProjectile()
    {
        if (isGuided)
        {
            if (target != null)
            {
                Direction = target.position - transform.position;
                transform.right = -Direction;
            }
        }
    }

    public float GetDamage()
    {
        float realDamage = player.Damage * damage;
        return realDamage;
    }
}
