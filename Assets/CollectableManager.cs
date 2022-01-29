using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectableManager : MonoBehaviour
{
    public int collectablesCollected = 0;
    public List<GameObject> collectablesInGame;
    
    [SerializeField] private GameObject prefabCollectable;
    [SerializeField] private float xMin, xMax, zMin, zMax, yPosition;
    [SerializeField] private float timeBetweenCollectableSpawn;

    private float timer;

    private void Start()
    {
        Services.CollectableManager = this;
    }

    private void Update()
    {
        SpawnTimer();
    }

    private void SpawnTimer()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenCollectableSpawn)
        {
            timer = 0;
            SpawnCollectable(); 
        }
    }

    private void SpawnCollectable()
    {
        float spawnPosX = Random.Range(xMin, xMax);
        float spawnPosZ = Random.Range(zMin, zMax);
        var obj = Instantiate(prefabCollectable, new Vector3(spawnPosX, yPosition, spawnPosZ), Quaternion.identity);
        collectablesInGame.Add(obj);
    }

    public void CollectablePickUp(GameObject collectedObject)
    {
        collectablesCollected++;
        collectablesInGame.Remove(collectedObject);
        Destroy(collectedObject);
    }

    public void DestroyPickUp(GameObject destroyObject)
    {
        collectablesInGame.Remove(destroyObject);
        Destroy(destroyObject);
    }
}
