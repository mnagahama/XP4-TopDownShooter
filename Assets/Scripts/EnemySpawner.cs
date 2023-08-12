using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject enemy2;

    [SerializeField]
    private float enemyInterval = 3f;
    [SerializeField]
    private float enemy2Interval = 6f;

    private float currentSpawnInterval;
    private float currentSpawn2Interval;



    void Start()
    {
        InvokeRepeating("SpawnEnemies", 3, enemyInterval);
        InvokeRepeating("SpawnEnemies2", 1, enemy2Interval);
    }

    void Update()
    {
        if (ScoreManager.score >= 10)
        {
            currentSpawnInterval = enemyInterval / 2f;
            currentSpawn2Interval = enemy2Interval / 2f;
        }

    }

    void SpawnEnemies()
    {
        int index = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[index].position, Quaternion.identity);

    }

    void SpawnEnemies2()
    {
        int index = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy2, spawnPoints[index].position, Quaternion.identity);

    }

}
