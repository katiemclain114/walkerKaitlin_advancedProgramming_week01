using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float speedPlayer = .1f;
    private Rigidbody rbPlayer;

    private void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float xDirection = Input.GetAxisRaw("Horizontal");
        float zDirection = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0, zDirection);

        rbPlayer.AddRelativeForce(moveDirection * speedPlayer);

        
    }
}
