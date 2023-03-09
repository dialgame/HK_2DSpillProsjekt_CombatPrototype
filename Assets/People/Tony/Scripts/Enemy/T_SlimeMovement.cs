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

    //DOTween variables
    [SerializeField] float duration;
    [SerializeField] float strength;

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
        }
    }

    private void OnCollisionEnter2D(Collision2D objectCollider)
    {
        Collider2D playerCollider = objectCollider.collider;
        T_PlayerStats damageable = objectCollider.collider.GetComponent<T_PlayerStats>();
        SpriteRenderer damageableSprite = objectCollider.collider.GetComponent<SpriteRenderer>();

        if(damageable != null )
        {
            Vector2 direction = (playerCollider.transform.position - transform.position).normalized;
            Vector2 knockbackEffect = direction * enemyStats.currentKnockbackForce;

            damageable.OnTakeDamage(enemyStats.currentAttackDamage, knockbackEffect);

            //Return back to original color?
            //damageableSprite.DOColor(Color.white, 1f);

            //losing knockbackEffect is tweening is used??
            //transform.DOComplete();

            //var playerPos = damageable.transform.DOShakePosition(duration, strength);

            //var playerRot = damageable.transform.DOShakeRotation(duration, strength);

            //var playerScale = damageable.transform.DOShakeScale(duration, strength);
            //if (playerScale.IsPlaying()) return;

            //transform.DOKill();
        }

    }



}
