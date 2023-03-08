using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    Collider2D collider2d;
    [SerializeField] T_PlayerBase playerBase;

    [HideInInspector] public float lastHorizontalVector;
    [HideInInspector] public float lastVerticalVector;
    [HideInInspector] public Vector2 moveDirection;
    [HideInInspector] public Vector2 lastMovedVector;

    private float cooldown;
    private float attackInterval = 1;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();
        //lastMovedVector = new Vector2(1, 0); //creates projectile mometum when instantiated. Dont need this?
    }

    void Update()
    {
        InputManagement();
    }

    private void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;//normalized goes between -1, 0 and 1.

        //checks direction inputs
        if(moveDirection.x != 0)
        {
            lastHorizontalVector= moveDirection.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f); //last moved X-vector
        }

        if (moveDirection.y != 0)
        {
            lastVerticalVector= moveDirection.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector); //last moved y-vector
        }

        if (moveDirection.x != 0 && moveDirection.y != 0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector); //last diagonal movement vectors
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        rb2d.velocity = new Vector2(moveDirection.x * playerBase.MoveSpeed, moveDirection.y * playerBase.MoveSpeed);
    }
}
