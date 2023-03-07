using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class T_EnemyStats : MonoBehaviour, T_IDamageable
{
    [SerializeField] T_EnemyBase enemyBase;
    Rigidbody2D rb2d;
    Collider2D col2d;

    bool targetable = true;
    public bool disableSimulation = false;

    //Enemy stats
    [HideInInspector] public int currentHealth;
    [HideInInspector] public int currentMoveSpeed;
    [HideInInspector] public int currentAttackDamage;
    [HideInInspector] public float currentAttackSpeed;
    [HideInInspector] public int currentDefense;

    private void Awake()
    {
        currentHealth = enemyBase.MaxHealth;
        currentMoveSpeed = enemyBase.MoveSpeed;
        currentAttackDamage = enemyBase.AttackDamage;
        currentAttackSpeed = enemyBase.AttackSpeed;
        currentDefense = enemyBase.Defense;

        rb2d= GetComponent<Rigidbody2D>();
        col2d = GetComponent<Collider2D>();
    }

    public void OnTakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            OnDeath();
        }
    }
    public void OnTakeDamage(int damage, Vector2 knockback)
    {
        currentHealth -= damage;

        //apply force to the slime
        rb2d.AddForce(knockback); //ForceMode2D.Impulse
        if (currentHealth <= 0)
        {
            OnDeath();
        }

    }

    public void OnDeath()
    {
        //Make it flashy
        Destroy(gameObject);
    }

    //If player touches the enemy, they take damage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Player loses health based on enemy currentAttackDamage.
            T_PlayerStats player = collision.gameObject.GetComponent<T_PlayerStats>();
            player.OnTakeDamage(currentAttackDamage);
        }
    }


    //property. Needed to specify target for Enemy.
    //public bool IsTargetable
    //{
    //    get { return targetable; }
    //    set
    //    {
    //        targetable = value;
    //        col2d.enabled = value;

    //        if (disableSimulation)//toggle
    //        {
    //            rb2d.simulated = false;//turns off physics when object dies.
    //        }
    //    }
    //}
}