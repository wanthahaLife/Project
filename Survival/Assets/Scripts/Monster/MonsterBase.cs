using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : RecycleObject
{
    [Header("몬스터 기본 데이터")]
    public float moveSpeed = 1.0f;
    public float maxHp = 1.0f;
    private float hp = 1.0f;
    public float knockBackSize = 3.0f;
    public float exp = 1.0f;

    protected Player player;
    Animator animator;
    readonly int isDie_String = Animator.StringToHash("isDie");
    protected Rigidbody2D rigid;
    //Collider2D collider;


    public float HP
    {
        get => hp;
        private set
        {
            hp = value;
            if(hp <= 0)
            {
                hp = 0;
                OnDie();
            }
        }
    }
    public float damage = 1.0f;
    public float Damage
    {
        get => damage;
        set => damage = value;
    }
    public float defense = 0.0f;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        //collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        StopAllCoroutines();
        if(player == null)
            player = GameManager.Instance.Player;
        rigid.simulated = true;
        //collider.enabled = true;
        HP = maxHp;
        knockBackSize = moveSpeed + 3.0f;
        animator.SetBool(isDie_String, false);  // 사망모션 애니메이션 파라메터 다시 false로 변경
        Damage = damage;
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.isPause) return;
        MoveMonster();
    }

    protected virtual void MoveMonster()
    {
        Vector2 direction = Vector2.right;
        if (player != null)
            direction = (Vector2)player.transform.position - rigid.position;
        rigid.MovePosition(rigid.position + (Vector2)(moveSpeed * Time.fixedDeltaTime * direction.normalized));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("PlayerWeapon"))
        {
            WeaponBase weapon = collision.gameObject.GetComponent<WeaponBase>();
            OnHit(weapon.GetDamage(), collision.transform);
        }
        if (collision.transform.CompareTag("PlayerBurst"))
        {
            BurstBase burst = collision.gameObject.GetComponent<BurstBase>();
            OnHit(burst.Damage, collision.transform);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerWeapon"))
        {
            WeaponBase weapon = collision.gameObject.GetComponent<WeaponBase>();
            OnHit(weapon.GetDamage(), collision.transform);
        }
        if (collision.transform.CompareTag("PlayerBurst"))
        {
            BurstBase burst = collision.gameObject.GetComponent<BurstBase>();
            OnHit(burst.Damage, collision.transform);
        }
    }

    void OnHit(float damage, Transform target)
    {
        float deal = damage - defense;
        if (deal < 1)
        {
            deal = 1;
        }
        HP -= deal;
        KnockBack(target);
    }

    void OnDie()
    {
        player.CurrExp += exp;
        player.KillCount++;
        rigid.simulated = false;
        //GetComponent<Collider>().enabled = false;
        animator.SetBool(isDie_String, true);
        float animLength = animator.GetCurrentAnimatorClipInfo(0).Length;
        Invoke(nameof(SetActiveFalse), animLength);
    }

    void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }

    void KnockBack(Transform target)
    {
        Vector3 targetPos = target.position;
        Vector3 directionVec = (transform.position - targetPos).normalized;
        rigid.AddForce(directionVec * knockBackSize, ForceMode2D.Impulse);
    }

    protected virtual void Reposition()
    {
        Vector3 distance = player.transform.position - transform.position;
        float randomDistance = UnityEngine.Random.value + 2.0f;
        transform.Translate(distance * randomDistance);
    }
}
