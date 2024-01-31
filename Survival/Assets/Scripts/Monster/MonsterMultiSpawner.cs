using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class MultiSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnData 
    {
        public MonsterType type;
        public int level;
        public float startMin;
        public float startSec;
        public float interval;
        public int generateCount;

        public SpawnData(MonsterType type = MonsterType.BasicMonster,
            int level = 0, float startMin = 0.0f,
            float startSec = 0.0f, float interval = 0.5f,
            int generateCount = 1)
        {
            this.type = type;
            this.level = level;
            this.startMin = startMin;
            this.startSec = startSec;
            this.interval = interval;
            this.generateCount = generateCount;
        }
    }


    public float horRange = 9.5f;
    public float verRange = 5.5f;
    public SpawnData[] spawnDatas;

    private const float OneTime = 60.0f;
    private WaitForSeconds spawnWait;
    private const float spawnWaitTime = 0.001f;


    private void Start()
    {
        spawnWait = new WaitForSeconds(spawnWaitTime);
        foreach (var data in spawnDatas)
        {
            StartCoroutine(SpwanIntervalCor(data));
        }
    }

    IEnumerator SpwanIntervalCor(SpawnData data)
    {
        float startSpawnTime = data.startMin * OneTime + data.startSec;
        yield return new WaitForSeconds(startSpawnTime);

        float interval = data.interval;
        WaitForSeconds waitInterval = new WaitForSeconds(interval);
        while (true)
        {
            StartCoroutine(Spawn(data));
            if(interval != data.interval)
            {
                interval = data.interval;
                waitInterval = new WaitForSeconds(interval);
            }
            yield return waitInterval;
        }
    }
    IEnumerator Spawn(SpawnData data)
    {
        Vector2 pos = GetSpawnPosition();
        for (int i = 0; i < data.generateCount; i++)
        {
            MonsterFactory.Instance.GetObject(data.type, data.level, pos);
            yield return spawnWait;
        }
    }

    Vector2 GetSpawnPosition()
    {
        Vector2 pos = transform.position;
        float random = Random.value;
        switch (random)
        {
            case < 0.25f:   // 위
                pos.y += verRange;
                pos.x += Random.Range(-horRange, horRange);
                break;
            case < 0.5f:    // 아래
                pos.y -= verRange;
                pos.x += Random.Range(-horRange, horRange);
                break;
            case < 0.75f:   // 왼쪽
                pos.x -= horRange;
                pos.y += Random.Range(-verRange, verRange);
                break;
            case < 1.0f:    // 오른쪽
                pos.x += horRange;
                pos.y += Random.Range(-verRange, verRange);
                break;
        }

        return pos;
    }
}
