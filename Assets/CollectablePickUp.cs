using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("pick up cube");
            Services.CollectableManager.CollectablePickUp(gameObject);
            Destroy(gameObject);
        }
        else if(other.tag == "Enemy")
        {
            Services.CollectableManager.DestroyPickUp(gameObject);
            Destroy(gameObject);
        }
        
    }
}
