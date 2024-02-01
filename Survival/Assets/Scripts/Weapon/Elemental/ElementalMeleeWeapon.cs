using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalMeleeWeapon : WeaponBase
{

    Transform originParent;
    protected override void OnEnable()
    {
        base.OnEnable();
        originParent = transform.parent;

    }
    protected override void OnDisable()
    {
        base.OnDisable();
    }

    public override void Init(ItemData data)
    {
        base.Init(data);
        // 지속시간, 연사속도(생성기), 투사제개수(생성기)
        LifeTime = data.baseDuration; 
    }

    public override void LevelUp(int level)
    {
        base.LevelUp(level);
        LifeTime = data.baseDuration + LifeTime * level;
    }

    protected override void MoveProjectile(float deltaTime, Vector3 direction)
    {
        /*Vector3 centerPosition = player.transform.GetChild((int)PlayerChild.CenterPosition).position;
        Vector3 offset = transform.position - centerPosition;
        float rotateSpeedPerTime = -rotateSpeed * Time.deltaTime;           // 시계방향 회전을 위해 - 적용
        transform.Rotate(Vector3.forward * rotateSpeedPerTime);
        transform.position = centerPosition + Quaternion.Euler(0,0,rotateSpeedPerTime) * offset;*/
        

    }

    protected override void RangeControl()
    {
    }

    protected override IEnumerator LifeOver()
    {
        if (lifeTime > -1)      // lifeTime 이 -1이면 무한 지속
        {
            yield return new WaitForSeconds(lifeTime); // delay만큼 기ㅏ리고
            transform.SetParent(originParent);
            gameObject.SetActive(false);            // 비활성화 
        }
    }
}
