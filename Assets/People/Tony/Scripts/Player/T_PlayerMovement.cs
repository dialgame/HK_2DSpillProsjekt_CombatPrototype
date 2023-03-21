using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    Collider2D collider2d;
    [SerializeField] T_PlayerBase playerBase;

    float horizontal;
    float vertical;

    bool isFacingRight = true;
    public bool canMove = true;
    bool isMoving = false;
    [SerializeField] private float idleFriction;


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
       // Flip();
    }

    private void InputManagement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(horizontal, vertical).normalized;//normalized goes between -1, 0 and 1.

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
        //rb2d.velocity = new Vector2(moveDirection.x * playerBase.MoveSpeed * Time.fixedDeltaTime, moveDirection.y * playerBase.MoveSpeed * Time.fixedDeltaTime);

        if (canMove == true && moveDirection != Vector2.zero)
        {
            rb2d.velocity = new Vector2(moveDirection.x * playerBase.MoveSpeed * Time.fixedDeltaTime, moveDirection.y * playerBase.MoveSpeed * Time.fixedDeltaTime);
            //resets scale after tweening
            transform.localScale = Vector3.one;

            if (moveDirection.x < 0)
            {
                //spriteRenderer.flipX = true;
                // playerTransform.rotation = Quaternion.Euler(0, 180, 0);
                // Animation: gameObject.BroadcastMessage("IsFacingRight", false);
            }
            else if (moveDirection.x > 0)
            {
                //spriteRenderer.flipX = false;
                //playerTransform.rotation = Quaternion.Euler(0, 0, 0);
                //Animation  gameObject.BroadcastMessage("IsFacingRight", true);
            }

            isMoving = true;
        }
        else
        {
            rb2d.velocity = Vector2.Lerp(rb2d.velocity, Vector2.zero, idleFriction);//Stops the player from sliding.
            isMoving = false;
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }
}
