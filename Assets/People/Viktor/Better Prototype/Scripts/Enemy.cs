using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public DetectionZone detectionZone;
    public float moveSpeed = 500f;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
        if (detectionZone.detectedObjects.Count > 0)
        {
            Vector2 direction = (detectionZone.detectedObjects[0].transform.position - transform.position).normalized;

            rb.AddForce(direction * moveSpeed * Time.deltaTime);
        }
    }
}
