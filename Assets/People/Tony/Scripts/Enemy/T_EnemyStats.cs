using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class T_EnemyStats : MonoBehaviour, T_IDamageable
{
    [SerializeField] GameManager gameManager;
    [SerializeField] T_EnemyBase enemyBase;

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

    //health bar
    [SerializeField]  HealthStatusBar healthStatusBar;

    //enemy spawner
    //public string enemyType;

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
    private void Update()
    {

    }

    public void OnTakeDamage(Vector2 knockback, ElementTypes elementType)
    {
        rb2d.AddForce(knockback); //ForceMode2D.Impulse
        Debug.Log("Player attcked the monster!");
    }


    public void OnTakeDamage(Vector2 knockback, ElementTypes elementType, int damage)
    {

        currentHealth -= elementResistance.CalculateDamageWithResistance(damage, elementType);
        Debug.Log(elementResistance.CalculateDamageWithResistance(damage, elementType));

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

    private void OnCollisionEnter2D(Collision2D objectCollider)
    {
        Collider2D playerCollider = objectCollider.collider.GetComponent<Collider2D>();
        T_PlayerStats damageable = objectCollider.collider.GetComponent<T_PlayerStats>();

        if (damageable != null)
        {
            //Non-element damage
            Vector2 direction = (playerCollider.transform.position - transform.position).normalized;
            Vector2 knockbackEffect = direction * currentKnockbackForce;

            //attack test!
            float critical = 1f;
            if (Random.value * 100f <= 6.25f)
            {
                critical = 2f;
            }

            float modifiers = Random.Range(0.85f, 1f) * critical;
            float damageValue = currentAttackDamage / damageable.currentDefense;

            int damageOutput = Mathf.FloorToInt(damageValue * modifiers);//Final dmg value rounded to int.


            damageable.OnTakeDamage(knockbackEffect, enemyElementType, damageOutput);
           // healthStatusBar.ChangeHealth(damageOutput);


            //clears dotween effect
            transform.DOKill();
            //change color
            damageable.GetComponent<SpriteRenderer>().color = Color.cyan;
            damageable.GetComponent<SpriteRenderer>().DOColor(Color.red, .5f).From();

            var enemyRot = playerCollider.transform.DOShakeRotation(duration, strength);

            //playerCollider.transform.localScale = Vector3.one;
            var enemyScale = playerCollider.transform.DOShakeScale(duration, strength);
            if (enemyScale.IsPlaying()) return;
            playerCollider.DOComplete();

            Debug.Log("Damage from Slime");
        }

    }


    //Ability variables
    public List<T_Ability> Abilities { get; set; }
    public T_EnemyStats(T_EnemyBase eBase)
    {
        enemyBase = eBase;

        Abilities = new List<T_Ability>();
        foreach (LearnableAbilities ability in enemyBase.LearnableAbilities)
        {
            Abilities.Add(new T_Ability(ability.AbilityBase));

            if (Abilities.Count >= 2)
            {
                break;//enemy got max two moves
            }
        }
    }

    public T_Ability GetRandomAbility()//calls upon a random move for enemy
    {
        //Dont need this funcion if enemy gets hardcoded abilities!
        int random = Random.Range(0, Abilities.Count);
        return Abilities[random];

    }


    //public string GetEnemyType()
    //{
    //    return enemyType;
    //}
}
