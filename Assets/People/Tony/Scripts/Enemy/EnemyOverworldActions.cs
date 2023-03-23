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
   // [SerializeField] T_EnemyStats enemyStats;


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

    //spawn enemy
    public GameObject[] slimePrefabs;
    public GameObject[] lionPrefabs;

    // Minimum distance between spawned enemies and player
    public float minDistanceToPlayer = 5f;
    // Minimum distance between spawned enemies
    public float minDistanceBetweenEnemies = 2f;

    // Combat arena location
    public Transform combatArena;


    private void Awake()
    {
        currentHealth = enemyBase.MaxHealth;
        currentMoveSpeed = enemyBase.MoveSpeed;
        currentAttackDamage = enemyBase.AttackDamage;
        currentAttackSpeed = enemyBase.AttackSpeed;
        currentDefense = enemyBase.Defense;
        currentKnockbackForce = enemyBase.KnockbackForce;

        rb2d = GetComponent<Rigidbody2D>();
        col2d = GetComponent<Collider2D>();
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

            SpawnEnemies();


            //clears dotween effect
            transform.DOKill();
            //change color
            damageable.GetComponent<SpriteRenderer>().color = Color.cyan;
            damageable.GetComponent<SpriteRenderer>().DOColor(Color.red, .5f).From();

            //var enemyRot = playerCollider.transform.DOShakeRotation(duration, strength);

            ////playerCollider.transform.localScale = Vector3.one;
            //var enemyScale = playerCollider.transform.DOShakeScale(duration, strength);
            //if (enemyScale.IsPlaying()) return;
            playerCollider.DOComplete();

        }

    }

    public void OnTakeDamage(int damage, Vector2 knockback, ElementTypes elementType)
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


    private void SpawnEnemies()
    {

        EnemyOverworldActions enemyController = GetComponent<EnemyOverworldActions>();

        enemyType = enemyController.enemyType;
        GameObject[] enemyPrefabs = null;

        switch (enemyType)
        {
            case EnemyType.Slime:
                enemyPrefabs = slimePrefabs;
                break;
            case EnemyType.Lion:
                enemyPrefabs = lionPrefabs;
                break;
            default:
                // Handle unknown enemy types here
                break;
        }

        if (enemyPrefabs != null)
        {
            int enemyCount = Random.Range(1, 4);
            Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;


            for (int i = 0; i < enemyCount; i++)
            {

                //Vector3 enemyPosition = combatArena.position + new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
                //Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], enemyPosition, Quaternion.identity);

                Vector3 enemyPosition = Vector3.zero;
                bool tooCloseToPlayer = true;
                bool tooCloseToOtherEnemy = true;

                // Keep trying to find a valid position until one is found
                while (tooCloseToPlayer || tooCloseToOtherEnemy)
                {
                    enemyPosition = combatArena.position + new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
                    float distanceToPlayer = Vector3.Distance(enemyPosition, playerPosition);
                    tooCloseToPlayer = distanceToPlayer < minDistanceToPlayer;

                    if (i > 0)
                    {
                        float distanceToOtherEnemy = Vector3.Distance(enemyPosition, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f));
                        tooCloseToOtherEnemy = distanceToOtherEnemy < minDistanceBetweenEnemies;
                    }
                    else
                    {
                        tooCloseToOtherEnemy = false;
                    }
                }

                Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], enemyPosition, Quaternion.identity);
            }
      
        }

    }

}
