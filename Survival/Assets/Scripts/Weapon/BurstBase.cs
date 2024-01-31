using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstBase : Weapon
{
    public float Duration
    {
        get => duration;
        set
        {
            if (duration != value)
            {
                duration = value;
                waitTime = Mathf.Max(duration, animLength);
            }
        }
    }

    Animator animator;

    float animLength;

    float waitTime;

    WaitForSeconds disableWait;

    Rigidbody2D rigid;

    Vector3 rigidOriginRange;
    Vector3 transformOriginRange;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animLength = animator.GetCurrentAnimatorClipInfo(0).Length;
        waitTime = Mathf.Max(duration, animLength);
        disableWait = new WaitForSeconds(waitTime);
        if(TryGetComponent<Rigidbody2D>(out rigid))
            rigidOriginRange = rigid.transform.localScale;
        transformOriginRange = transform.localScale;
    }

    public override void Init(ItemData data)
    {
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        StopAllCoroutines();
        EnableSetting();
        RangeControl();
        StartCoroutine(WaitAnimCor());

    }
    protected override void OnDisable()
    {
        base.OnDisable();
        if (rigid != null)
            rigid.transform.localScale = rigidOriginRange;
        transform.localScale = transformOriginRange;

    }
    protected virtual void EnableSetting()
    {

    }

    protected virtual void RangeControl()
    {
        if (rigid != null)
        {
            rigid.transform.localScale *= range;
            transform.localScale *= range;
        }
    }

    IEnumerator WaitAnimCor()
    {
        yield return disableWait;
        gameObject.SetActive(false);
    }
}
