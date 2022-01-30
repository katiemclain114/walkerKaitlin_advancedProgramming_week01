using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Transform targetLocation;

    private void Start()
    {
        
    }

    private void Update()
    {
        FindClosestCollectable();
        MoveTowardsTarget();
    }

    public void FindClosestCollectable()
    {
        targetLocation = null;
        float closestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        if (Services.CollectableManager.collectablesInGame.Count == 0) return;
        foreach (GameObject collectable in Services.CollectableManager.collectablesInGame)
        {
            Vector3 directionToTarget = collectable.transform.position - currentPosition;
            float directionSqr = directionToTarget.sqrMagnitude;
            if (directionSqr < closestDistance)
            {
                closestDistance = directionSqr;
                targetLocation = collectable.transform;
            }
        }
    }

    public void MoveTowardsTarget()
    {
        if (targetLocation == null) return;
        
        Vector3 targetWithoutY = targetLocation.transform.position;
        targetWithoutY = new Vector3(targetWithoutY.x, transform.position.y, targetWithoutY.z);

        transform.position = Vector3.MoveTowards(transform.position, targetWithoutY,
            Time.deltaTime * Services.EnemyManager.enemySpeed);

    }
}
