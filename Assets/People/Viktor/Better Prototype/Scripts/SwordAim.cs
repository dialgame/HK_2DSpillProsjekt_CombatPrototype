using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SwordAim : MonoBehaviour
{
    private Camera mainCam;                     //CURRENT ISSUE THAT NEEDS FIX AND THOUGHT: When flipping the player to the left when direction is locked, the direction flips. One solution is to lock the player's ability to flip during an attack, as it doesn't make sense to attack one way and turn in the other direction. If we go another route, this needs bugfixing. If player aims left the sprite flips
    private Vector3 mousePos;
    private float horizontal;

    private bool isAnimationPlaying = false;

    private bool isFacingRight = true;

    public static SwordAim instance;

    private void Awake()
    {
        instance = this;
    }

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

        Vector3 direction = mousePos - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        float snappedAngle = Mathf.Round(angle / 45.0f) * 45.0f;

        if (snappedAngle < 0.0f)
        {
            snappedAngle += 360.0f;
        }


        if (!isAnimationPlaying)
        {
            if (snappedAngle > 337.5f || snappedAngle < 22.5f)
            {
                // right
                transform.rotation = Quaternion.Euler(0, 0, 0);

            }
            else if (snappedAngle >= 22.5f && snappedAngle < 67.5f)
            {
                // up-right
                transform.rotation = Quaternion.Euler(0, 0, 45);

            }
            else if (snappedAngle >= 67.5f && snappedAngle < 112.5f)
            {
                // up
                transform.rotation = Quaternion.Euler(0, 0, 90);

            }
            else if (snappedAngle >= 112.5f && snappedAngle < 157.5f)
            {
                // up-left
                transform.rotation = Quaternion.Euler(0, 0, 135);

            }
            else if (snappedAngle >= 157.5f && snappedAngle < 202.5f)
            {
                // left
                transform.rotation = Quaternion.Euler(0, 0, 180);

            }
            else if (snappedAngle >= 202.5f && snappedAngle < 247.5f)
            {
                // down-left
                transform.rotation = Quaternion.Euler(0, 0, 225);

            }
            else if (snappedAngle >= 247.5f && snappedAngle < 292.5f)
            {
                // down
                transform.rotation = Quaternion.Euler(0, 0, 270);

            }
            else if (snappedAngle >= 292.5f && snappedAngle < 337.5f)
            {
                // down-right
                transform.rotation = Quaternion.Euler(0, 0, 315);

            }
        } else
        {
            //if animation is playing, aka playing is performing an attack, then changing directions is locked
        }


        

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

    public void AnimationIsPlaying()
    {
        isAnimationPlaying = true;
    }

    public void AnimationFinished()
    {
        isAnimationPlaying = false;
    }
}