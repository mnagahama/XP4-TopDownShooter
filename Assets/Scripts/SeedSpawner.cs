using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject seed;
    

    [SerializeField]
    private float seedInterval = 3f;

    void Start()
    {
        InvokeRepeating("SpawnSeed", 1, seedInterval);

    }

    void Update()
    {
        /*if (ScoreManager.score >= 10)
        {
            currentSpawnInterval = enemyInterval / 2f;
            currentSpawn2Interval = enemy2Interval / 2f;
        }*/
    }

    void SpawnSeed()
    {
        if (PlayerController.currentAmmo != 5)
        {
            int index = Random.Range(0, spawnPoints.Length);
            Instantiate(seed, spawnPoints[index].position, Quaternion.identity);

        }

    }

}
