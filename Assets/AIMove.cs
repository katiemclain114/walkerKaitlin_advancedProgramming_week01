using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour
{

    private Transform targetPosition;
    private void Update()
    {
        targetPosition = Services.AILifecycleManager.AITargeting(gameObject);
        Services.AILifecycleManager.MoveTowardsTarget(targetPosition, gameObject);
    }
}
