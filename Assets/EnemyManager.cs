using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject prefabEnemy;
    [SerializeField] private bool spawnNewEnemies;
    [SerializeField] private int spawnNumberAtStart;
    [SerializeField] private float timeBetweenEnemySpawn = 4f;
    [SerializeField] private float xMin, xMax, zMin, zMax, yPosition;
    public float enemySpeed = 1;
    
    private float timer;

    private void Start()
    {
        Services.EnemyManager = this;

        for (int i = 0; i < spawnNumberAtStart; i++)
        {
            EnemySpawner();
        }
    }

    public void Update()
    {
        if(spawnNewEnemies) EnemySpawnTimer();
    }

    private void EnemySpawnTimer()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenEnemySpawn)
        {
            timer = 0;
            EnemySpawner(); 
        }
    }

    private void EnemySpawner()
    {
        float spawnPosX = Random.Range(xMin, xMax);
        float spawnPosZ = Random.Range(zMin, zMax);
        Instantiate(prefabEnemy, new Vector3(spawnPosX, yPosition, spawnPosZ), Quaternion.identity);
    }
    
    //spawn enemies
    //move enemies ---> individual gameObject
    //destroy enemies
    //track all enemies
}
