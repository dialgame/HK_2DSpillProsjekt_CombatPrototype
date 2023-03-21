using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private float horizontal;
    public float vertical;
    public float speed = 8f;
    public float jumpingPower = 16f;
    public LayerMask ground;

    private bool isFacingRight = true;


    

    
    Rigidbody2D rb;

   


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.y, jumpingPower);
        }
        //if u hold jump longer u jump higher
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        //Raycast grounded check
        bool IsGrounded()
        {


            Vector2 position = transform.position;
            Vector2 direction = Vector2.down;
            float distance = 0.8f;



            Debug.DrawRay(position, direction, Color.green);
            RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, ground);
            if (hit.collider != null)
            {
                return true;
            }

            return false;
        }

        

        //Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);

       

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


    
}
