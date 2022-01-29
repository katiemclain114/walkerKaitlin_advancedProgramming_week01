using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject prefabEnemy;
    [SerializeField] private float timeBetweenEnemySpawn = 4f;
    [SerializeField] private float xMin, xMax, zMin, zMax, yPosition;
    
    private float timer;

    public void EnemyUpdate()
    {
        EnemySpawnTimer();
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
