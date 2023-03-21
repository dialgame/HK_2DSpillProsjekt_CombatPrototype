using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class T_SlimeMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    Collider2D collider2d;
    T_EnemyStats enemyStats;
    T_PlayerStats playerStats;

    //SpriteRenderer spriteColor;

    [SerializeField] T_Enemy_DetectionZone detectionZone;

    ////DOTween variables
    //[SerializeField] float duration;
    //[SerializeField] float strength;

    private void Awake()
    {
        rb2d= GetComponent<Rigidbody2D>();
        enemyStats= GetComponent<T_EnemyStats>();
        playerStats= FindObjectOfType<T_PlayerStats>();
        collider2d = GetComponent<Collider2D>();

    }

    private void FixedUpdate()
    {
        if(playerStats.IsTargetable && detectionZone.detectedObjects.Count > 0)
        {
            Vector2 direction = (detectionZone.detectedObjects[0].transform.position- transform.position).normalized;
            rb2d.AddForce(direction * enemyStats.currentMoveSpeed * Time.fixedDeltaTime);
            
            //resets scale after tweening
            transform.localScale = Vector3.one;

        }
    }

    //Slime deals dmg from collision in enemy stats, because every enemy have collision dmg.
    //Can add another attack function if slime actually attacks


}
