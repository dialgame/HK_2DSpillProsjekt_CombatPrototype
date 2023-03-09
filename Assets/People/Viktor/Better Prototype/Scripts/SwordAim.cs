using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SwordAim : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    private float horizontal;

    

    private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition); //setting vector 3 to our input mouse position

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg; //Rad2deg Converts radience to degrees


        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        Flip();
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
