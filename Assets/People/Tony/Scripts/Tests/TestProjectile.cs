using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private int damage;
    [SerializeField] private ElementTypes elementType;

    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * force, ForceMode2D.Impulse);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<TestEnemy>() != null)
        {
            collision.collider.GetComponent<TestEnemy>().DealDamage(damage, elementType);
        }
        Destroy(gameObject);
    }
}
