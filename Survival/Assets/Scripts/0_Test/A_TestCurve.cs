using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_TestCurve : MonoBehaviour
{
    public Transform curvePath; // 곡선을 그린 빈 게임 오브젝트
    public float speed = 5f; // 이동 속도

    private LineRenderer lineRenderer;
    private float t = 0f;

    void Start()
    {
        lineRenderer = curvePath.GetComponent<LineRenderer>();
    }

    void Update()
    {
        MoveAlongCurve();
    }

    void MoveAlongCurve()
    {
        if (t <= 1f)
        {
            t += Time.deltaTime * speed / Vector3.Distance(lineRenderer.GetPosition(0), lineRenderer.GetPosition(1));

            Vector3 newPosition = BezierCurve(t, lineRenderer.GetPosition(0), lineRenderer.GetPosition(1), lineRenderer.GetPosition(2));
            transform.position = newPosition;
        }
        else
        {
            // 곡선을 따라 도달한 후의 동작 또는 초기화 로직을 추가할 수 있습니다.
        }
    }

    Vector3 BezierCurve(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * p0;
        p += 3 * uu * t * p1;
        p += 3 * u * tt * p2;
        p += ttt * p2;

        return p;
    }
}
