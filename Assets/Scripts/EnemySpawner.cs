using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject enemy;
    void Start()
    {
        InvokeRepeating("SpawnEnemies", 2, 1f);
    }
    
    void SpawnEnemies()
    {
        int index = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[index].position, Quaternion.identity);
    }
}
