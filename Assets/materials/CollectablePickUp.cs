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
        }
    }
}
