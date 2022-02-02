using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public static class Services
{
    public static void InitializeServices()
    {
        Services.AILifecycleManager = new AILifecycleManager();
        Services.CollectableManager = new CollectableManager();
    }


    public static GameManager GameManager;
    public static PlayerManager PlayerManager;
    public static CollectableManager CollectableManager;
    public static AILifecycleManager AILifecycleManager;
}

public class GameManager : MonoBehaviour
{
    [Header("Max/Min of x/z for screen boarders")]
    public float xMin, xMax, zMin, zMax, yPositionEnemies, yPositionCollectables;

    [Header("Enemy Information")]
    public GameObject prefabEnemy;
    public int numberOfEnemiesAtStart;
    //public bool spawnNewEnemies;
    //public float timeBetweenEnemySpawn;
    public float enemySpeed;
    [HideInInspector] float timerEnemy;

    [Header("Collectable Information")]
    public GameObject prefabCollectable;
    public int numberOfCollectablesAtStart;
    public float timeBetweenCollectableSpawn;

    [Header("Not for editing || Score of Player")]
    public int collectablesCollected;
    [HideInInspector] float timerCollectable;

    private void Start()
    {
        Services.InitializeServices();
        Services.GameManager = this;
        Services.AILifecycleManager.AIStart();
        Services.CollectableManager.CollectableStart();
    }

    private void Update()
    {
        Services.CollectableManager.CollectableUpdate();
    }

    public GameObject CreateGameObject(int typeOfSpawnObject)
    {
        if(typeOfSpawnObject == 0) // 0 is for ai
        {
            float spawnPosX = Random.Range(Services.GameManager.xMin, Services.GameManager.xMax);
            float spawnPosZ = Random.Range(Services.GameManager.zMin, Services.GameManager.zMax);
            GameObject newObj = Instantiate(prefabEnemy, new Vector3(spawnPosX, yPositionEnemies, spawnPosZ), Quaternion.identity);
            return newObj;
        }
        else if(typeOfSpawnObject == 1) // 1 is for collectables
        {
            float spawnPosX = Random.Range(Services.GameManager.xMin, Services.GameManager.xMax);
            float spawnPosZ = Random.Range(Services.GameManager.zMin, Services.GameManager.zMax);
            GameObject newObj = Instantiate(prefabCollectable, new Vector3(spawnPosX, yPositionCollectables, spawnPosZ), Quaternion.identity);
            return newObj;
        }
        return null;
        
    }

    
}

public class AILifecycleManager
{
    List<GameObject> aiInGame = new List<GameObject>();

    public void AIStart()
    {
        for (int i = 0; i < Services.GameManager.numberOfEnemiesAtStart; i++)
        {
            AICreation();
        }
    }


    private void AICreation()
    {
        aiInGame.Add(Services.GameManager.CreateGameObject(0));
    }


    public Transform AITargeting(GameObject aiGameObject)
    {
        Transform targetLocation = null;
        float closestCollectable = Mathf.Infinity;
        Vector3 currentPosition = aiGameObject.transform.position;
        if (Services.CollectableManager.collectablesInGame.Count == 0) return null;
        foreach (GameObject collectable in Services.CollectableManager.collectablesInGame)
        {
            Vector3 directionToTarget = collectable.transform.position - currentPosition;
            float directionSqr = directionToTarget.sqrMagnitude;
            if (directionSqr < closestCollectable)
            {
                closestCollectable = directionSqr;
                targetLocation = collectable.transform;
            }
        }
        return targetLocation;

    }

    public void MoveTowardsTarget(Transform targetLocation, GameObject aiGameObject)
    {
        if (targetLocation != null)
        {
            Vector3 targetWithoutY = targetLocation.transform.position;
            targetWithoutY = new Vector3(targetWithoutY.x, aiGameObject.transform.position.y, targetWithoutY.z);

            aiGameObject.transform.position = Vector3.MoveTowards(aiGameObject.transform.position, targetWithoutY,
                Time.deltaTime * Services.GameManager.enemySpeed);
        }

    }
}

public class CollectableManager
{
    public List<GameObject> collectablesInGame = new List<GameObject>();
    private float timer;

    public void CollectableStart()
    {
        for (int i = 0; i < Services.GameManager.numberOfCollectablesAtStart; i++)
        {
            CollectableCreation();
        }
    }

    public void CollectableUpdate()
    {
        SpawnTimer();
    }

    private void CollectableCreation()
    {
        collectablesInGame.Add(Services.GameManager.CreateGameObject(1));
    }

    private void SpawnTimer()
    {
        timer += Time.deltaTime;
        if (timer > Services.GameManager.timeBetweenCollectableSpawn)
        {
            timer = 0;
            CollectableCreation();
        }
    }

    public void CollectablePickUp(GameObject collectedObject)
    {
        Services.GameManager.collectablesCollected++;
        collectablesInGame.Remove(collectedObject);
    }

    public void DestroyPickUp(GameObject destroyObject)
    {
        collectablesInGame.Remove(destroyObject);
    }
}


