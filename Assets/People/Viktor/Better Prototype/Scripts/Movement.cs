using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private float horizontal;
    public float vertical;
    public float speed = 5f;
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

        
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 10f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5f;
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
