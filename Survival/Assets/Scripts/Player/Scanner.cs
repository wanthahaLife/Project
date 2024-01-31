using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Scanner : MonoBehaviour
{
    public float scanRange;
    public LayerMask targerLayer;
    public RaycastHit2D[] targets;
    public Transform nearestTarget;

    private void FixedUpdate()
    {
        if(GameManager.Instance.isPause) return;
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targerLayer);
        nearestTarget = GetNearest();
    }

    Transform GetNearest()
    {
        Transform result = null;
        float diff = 100;

        foreach (RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(myPos, targetPos);

            if(curDiff < diff)
            {
                diff = curDiff;
                result = target.transform;
            }
        }

        return result;
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        int segments = 36; // 원을 구성하는 선분의 수

        Vector3 center = transform.position;
        float radius = scanRange;

        // 선분들을 그리기
        for (int i = 0; i < segments; i++)
        {
            float angle = i * 2 * Mathf.PI / segments;
            float x = center.x + Mathf.Cos(angle) * radius;
            float z = center.z + Mathf.Sin(angle) * radius;
            Vector3 pos = new Vector3(x, center.y, z);
            Vector3 nextPos = new Vector3(center.x + Mathf.Cos((i + 1) * 2 * Mathf.PI / segments) * radius, center.y, center.z + Mathf.Sin((i + 1) * 2 * Mathf.PI / segments) * radius);
            Gizmos.DrawLine(pos, nextPos);
        }
    }*/
}
