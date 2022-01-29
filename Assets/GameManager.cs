using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public static class Services
{
    
    public static GameManager GameManager;
    public static PlayerManager PlayerManager;
    public static CollectableManager CollectableManager;
    public static EnemyManager EnemyManager;
}

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Services.GameManager = this;
    }

    
}

// public class EnemyManager
// {
//     private float timeBetweenEnemySpawn = 4f;
//     private float timer;
//
//     public void EnemyUpdate()
//     {
//         EnemySpawnTimer();
//     }
//     
//     private void EnemySpawnTimer()
//     {
//         timer += Time.deltaTime;
//         if (timer > timeBetweenEnemySpawn)
//         {
//             timer = 0;
//             //spawnEnemy 
//         }
//     }
//
//     private void EnemySpawner()
//     {
//         
//     }
//     
//     //spawn enemies
//     //move enemies ---> individual gameObject
//     //destroy enemies
//     //track all enemies
// }
