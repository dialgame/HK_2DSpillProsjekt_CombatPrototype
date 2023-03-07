using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_SlimeMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    T_EnemyStats enemyStats;
    T_PlayerStats playerStats;

    [SerializeField] T_Enemy_DetectionZone detectionZone;

    //public float damage = 1;
    public float knockbackForce = 300f;
    //public int moveSpeed = 15;

    private void Awake()
    {
        rb2d= GetComponent<Rigidbody2D>();
        enemyStats= GetComponent<T_EnemyStats>();
        playerStats= FindObjectOfType<T_PlayerStats>();
    }

    private void FixedUpdate()
    {
        if(playerStats.IsTargetable && detectionZone.detectedObjects.Count > 0)
        {
            Vector2 direction = (detectionZone.detectedObjects[0].transform.position- transform.position).normalized;
            rb2d.AddForce(direction * enemyStats.currentMoveSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D objectCollider)
    {
        Collider2D playerCollider = objectCollider.collider;
        T_PlayerStats damageable = objectCollider.collider.GetComponent<T_PlayerStats>();

        if(damageable != null )
        {
            Vector2 direction = (playerCollider.transform.position - transform.position).normalized;
            Vector2 knockbackEffect = direction * knockbackForce;

            damageable.OnTakeDamage(enemyStats.currentAttackDamage, knockbackEffect);
        }

    }


}
