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

    //Dash
    bool isDashing;
    private float dashTimeLeft;//how much longer the dash should be happening.
    private float lastImageXpos;//keep track of the last x-coordinate we will replace with an afterimage
    private float lastImageYpos;//keep track of the last x-coordinate we will replace with an afterimage
    private float lastDash = -100f;//keep track of the last time you dashed. will be used to check for the cooldown.

    public float dashTime;//how long the dash should take
    public float dashSpeed;//how fast the player should move when dashing
    public float distanceBetweenImages;//how far apart the afterImage GO should be placen when dashing.'
    public float dashCooldown;//how long we have to wait before we can Dash again.

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();
        //lastMovedVector = new Vector2(1, 0); //creates projectile mometum when instantiated. Dont need this?
    }

    void Update()
    {
        InputManagement();
        CheckDash();
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

        //Dash
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time >= (lastDash + dashCooldown))
            {
                AttemptToDash();//only able to dash after cooldown

            }
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

    private void AttemptToDash()
    {
        isDashing = true;
        dashTimeLeft = dashTime;
        lastDash = Time.time;

        AfterImagePool.Instance.GetFromPool();
        lastImageXpos = transform.position.x;
        lastImageYpos = transform.position.y;
    }

    private void CheckDash()//setting the dash velocity, and checks if we should be dashing or stop
    {
        if (isDashing)
        {
            if(dashTimeLeft > 0)
            {
                canMove= false;
                isFacingRight = false;

                rb2d.velocity = new Vector2(dashSpeed * moveDirection.x, dashSpeed * moveDirection.y);
                dashTimeLeft -= Time.deltaTime;

                if(Mathf.Abs(transform.position.x - lastImageXpos) > distanceBetweenImages)//checks if enough distance has passed for us to place another iamge
                {
                    AfterImagePool.Instance.GetFromPool();
                    lastImageXpos = transform.position.x;
                }

                if (Mathf.Abs(transform.position.y - lastImageYpos) > distanceBetweenImages)//checks if enough distance has passed for us to place another iamge
                {
                    AfterImagePool.Instance.GetFromPool();
                    lastImageYpos = transform.position.y;
                }


            }

            if(dashTimeLeft <= 0)
            {
                isDashing = false;
                canMove = true;
                isFacingRight  = true;
            }
        }
    }

    public void LockMovement()
    {
        canMove = false;
            isFacingRight = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
            isFacingRight = true;
    }
}
