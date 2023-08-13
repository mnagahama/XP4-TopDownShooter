using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject seed;
    

    [SerializeField]
    private float seedInterval = 1f;
    private float currentSpawnInterval;

    private int maxSeeds = 7;
    private int currentSeeds = 0;

    void Start()
    {
        InvokeRepeating("SpawnSeed", 1, seedInterval);

    }

    void Update()
    {
         if(ScoreManager.score >= 10)
        {
            currentSpawnInterval = seedInterval / 2f;
        }
    }

    void SpawnSeed()
    {
       
        if (currentSeeds <= maxSeeds && PlayerController.currentAmmo != 5)
        {
            int index = Random.Range(0, spawnPoints.Length);
            Instantiate(seed, spawnPoints[index].position, Quaternion.identity);
           currentSeeds++;
        }

    }
    public void SeedDestroyed()
    {
        currentSeeds--;
    }

}
