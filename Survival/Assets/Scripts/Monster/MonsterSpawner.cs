using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UIElements;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monster;
    public float startSpawnMin = 0.0f;
    public float startSpawnSec = 0.0f;
    float startSpawnTime = 0.0f;
    public float spawnInterval = 0.1f;
    public float mapRange = 1.0f;

    private const float Minute = 60.0f;

    protected int level = 0;
    protected MonsterType monsterType = MonsterType.BasicMonster;

    private void Start()
    {
        startSpawnTime = startSpawnMin * Minute + startSpawnSec;
        Invoke("StartSpawn", startSpawnTime);
    }
    private void StartSpawn()
    {
        StartCoroutine(SpwanIntervalCor());
    }

    IEnumerator SpwanIntervalCor()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    protected void Spawn()
    {
        MonsterFactory.Instance.GetObject(monsterType, level, GetSpawnPosition());
    }

    Vector2 GetSpawnPosition()
    {
        Vector2 pos = transform.position;
        pos.y += Random.Range(-mapRange, mapRange);
        return pos;
    }
}
