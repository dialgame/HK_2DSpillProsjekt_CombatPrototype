using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public enum EnemyType
{
    Slime,
    Lion
}
public class EnemyOverworldActions : MonoBehaviour, T_IDamageable
{
    public EnemyType enemyType;
    [SerializeField] ShatteredScreenTestManager shatterScreen;
    [SerializeField] T_EnemyBase enemyBase;

    [SerializeField] EnemyAttackSpawner enemySpawner;
    [SerializeField] PlayerAttackSpawner playerAttackSpawner;



    Rigidbody2D rb2d;
    Collider2D col2d;

    bool targetable = true;
    public bool disableSimulation = false;

    //Enemy stats
    public int currentHealth;
    [HideInInspector] public int currentMoveSpeed;
    [HideInInspector] public int currentAttackDamage;
    [HideInInspector] public float currentAttackSpeed;
    [HideInInspector] public int currentDefense;
    [HideInInspector] public int currentKnockbackForce;

    //DOTween variables
    [SerializeField] float duration;
    [SerializeField] float strength;

    //ElementStats
    [SerializeField] private ElementResistanceSO elementResistance;
    [SerializeField] private ElementTypes enemyElementType; //declare which element it is in the SO

    private void Awake()
    {
        currentHealth = enemyBase.MaxHealth;
        currentMoveSpeed = enemyBase.MoveSpeed;

        currentKnockbackForce = enemyBase.KnockbackForce;

        rb2d = GetComponent<Rigidbody2D>();
        col2d = GetComponent<Collider2D>();
    }
    private void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D objectCollider)
    {
        Collider2D playerCollider = objectCollider.collider.GetComponent<Collider2D>();
        T_PlayerStats damageable = objectCollider.collider.GetComponent<T_PlayerStats>();

        if (damageable != null)
        {
            shatterScreen.ShatterScreen();

            //Non-element damage
            Vector2 direction = (playerCollider.transform.position - transform.position).normalized;
            Vector2 knockbackEffect = direction * currentKnockbackForce;



            float modifiers = Random.Range(0.85f, 1f); //change stats based on element
            //float damageValue = currentAttackDamage / damageable.currentDefense;

            //int damageOutput = Mathf.FloorToInt(damageValue * modifiers);//Final dmg value rounded to int.

            damageable.OnTakeDamage(knockbackEffect, enemyElementType);

            enemySpawner.SpawnEnemies();
            enemySpawner.enabled = false;
            playerAttackSpawner.enabled = false;


            //clears dotween effect
            transform.DOKill();
            //change color
            damageable.GetComponent<SpriteRenderer>().color = Color.cyan;
            damageable.GetComponent<SpriteRenderer>().DOColor(Color.red, .5f).From();

            playerCollider.DOComplete();

        }

    }

    public void OnTakeDamage(Vector2 knockback, ElementTypes elementType, int damage)
    {
        
        //Do nothing
    }

    public void OnTakeDamage(Vector2 knockback, ElementTypes elementType)
    {
        //Do nothing
    }

    public void OnDeath()
    {
        //Do nothing
    
    }


   

}
