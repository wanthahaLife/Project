using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float damage = 1.0f;
    public float Damage
    {
        get => damage;
    }
    private int level = 0;
    public int Level
    {
        get => level;
        set
        {
            if (level < value)
            {
                level = value;
                LevelUp();
            }
        }
    }
    public float maxExp = 20.0f;
    public float MaxExp
    {
        get => maxExp;
        private set => maxExp = value;
    }

    private int killCount = 0;
    public int KillCount
    {
        get => killCount;
        set
        {
            killCount = value;
            killMonster?.Invoke();
        }
    }

    public float currExp = 0.0f;
    public float CurrExp
    {
        get => currExp;
        set
        {
            if (currExp != value)
            {
                currExp = value;
            }

            if (currExp > maxExp)
            {
                currExp = currExp - maxExp;
                Level++;
            }
        }
    }

    public float maxHP = 100.0f;
    public float MaxHP
    {
        get => maxHP;
        set => maxHP = value;
    }
    float hp;
    public float HP
    {
        get => hp;
        set
        {
            if (hp != value)
            {
                hp = value;
                takeDamage?.Invoke();
                if (hp < 0)
                {
                    Dead();
                }
                else if (hp > maxHP)
                {
                    hp = maxHP;
                }
            }
        }
    }

    public Action killMonster;
    public Action onLevelUp;
    public Action takeDamage;

    PlayerInputActions inputActions;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Transform firePosFlip;
    public Scanner scanner;

    public Transform FirePosFlip
    {
        get => firePosFlip;
    }
    Transform firePosRotate;

    Vector3 inputDirection;
    Vector2 movePosition;
    public Vector3 MovePosition{
        get => movePosition;
    }

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        firePosFlip = transform.GetChild(0);
        firePosRotate = transform.GetChild(1);
        scanner = GetComponent<Scanner>();
        HP = maxHP;
    }

    private void Start()
    {
        Level++;
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
    }
    private void OnDisable()
    {
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        inputDirection = context.ReadValue<Vector2>();
    }
   
    private void FixedUpdate()
    {
        if (GameManager.Instance.isPause) return;
        movePosition = (Vector2)(Time.fixedDeltaTime * moveSpeed * inputDirection);
        FlipCheck();
        ChildPostionRotate();

        rigid.MovePosition(rigid.position + movePosition);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Monster"))
        {
            HP -= collision.gameObject.GetComponent<MonsterBase>().Damage;
        }
    }

    public Vector3 InputDirectionNormalized()
    {
        return inputDirection.normalized;
    }

    void FlipCheck()
    {
        if (movePosition.x != 0)
        {
            spriteRenderer.flipX = movePosition.x < 0;
            ChildPositionFlip();
        }
    }

    void ChildPositionFlip()
    {
        Vector3 flipVec = firePosFlip.localPosition;
        flipVec.x = movePosition.normalized.x * 0.5f;
        firePosFlip.localPosition = flipVec;

    }

    void ChildPostionRotate()
    {
        if (movePosition != Vector2.zero)
        {
            firePosRotate.localPosition = movePosition.normalized;
        }
    }

    private void LevelUp()
    {
        onLevelUp?.Invoke();
        maxExp *= 1.2f;
    }

    void Dead()
    {
        SceneChanger sceneChanger = new SceneChanger();
        sceneChanger.OverMenu();
    }
}
