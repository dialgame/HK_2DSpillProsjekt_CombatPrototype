using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Runtime.ConstrainedExecution;

public class T_EnemyStats : MonoBehaviour, T_IDamageable
{
    [SerializeField] T_EnemyBase enemyBase;
    //[SerializeField] T_AbilitySO abilityBase;

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
    public ElementType currentEnemyType;

    //DOTween variables
    [SerializeField] float duration;
    [SerializeField] float strength;

    //ElementStats
    //public ElementType currentType;



    private void Awake()
    {
        currentHealth = enemyBase.MaxHealth;
        currentMoveSpeed = enemyBase.MoveSpeed;
        currentAttackDamage = enemyBase.AttackDamage;
        currentAttackSpeed = enemyBase.AttackSpeed;
        currentDefense = enemyBase.Defense;
        currentKnockbackForce = enemyBase.KnockbackForce;
        currentEnemyType = enemyBase.EnemyType; //choose which element in SO!

        rb2d = GetComponent<Rigidbody2D>();
        col2d = GetComponent<Collider2D>();
    }

    public void OnTakeDamage(ElementType type)
    {
        //overworld element type check when attacking or taking an attack
    }

    public void OnTakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
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
    public void OnTakeDamage(T_Ability ability, int damage, Vector2 knockback, ElementType type)
    {

        float critical = 1f;
        if (Random.value * 100f <= 6.25f)
        {
            critical = 2f;
        }


        float enemyType = TypeChart.TypeEffectiveness(ability.AbilityBase.AbilityType, this.enemyBase.EnemyType);

        DamageDetails damageDetails = new DamageDetails()
        {
            TypeEffectiveness = enemyType,
            Critical = critical,
            Death = false,
        };

        float modifiers = Random.Range(0.85f, 1f) * enemyType * critical;

        //float attackDamage = (2 * enemyBase.AttackDamage + 10) / 250f;

        float damageValue = ability.AbilityBase.AbilityPower * (currentAttackDamage / currentDefense);
        int damageOutput = Mathf.FloorToInt(damageValue * modifiers);//Final dmg value rounded to int.

        currentHealth -= damageOutput;

        //apply force to the slime
        rb2d.AddForce(knockback); //ForceMode2D.Impulse
        if (currentHealth <= 0)
        {
            damageDetails.Death = true;
            OnDeath();
        }
        //return damageDetails;
    }


    public void OnDeath()
    {
        //Make it flashy
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D objectCollider)
    {
        Collider2D playerCollider = objectCollider.collider;
        T_PlayerStats damageable = objectCollider.collider.GetComponent<T_PlayerStats>();
        SpriteRenderer damageableSprite = objectCollider.collider.GetComponent<SpriteRenderer>();
       // T_Ability ability;

        if (damageable != null)
        {
            Vector2 direction = (playerCollider.transform.position - transform.position).normalized;
            Vector2 knockbackEffect = direction * currentKnockbackForce;

            ////attack test!
            //float critical = 1f;
            //if (Random.value * 100f <= 6.25f)
            //{
            //    critical = 2f;
            //}

            //float enemyType = TypeChart.TypeEffectiveness(ability.AbilityBase.AbilityType, this.enemyBase.Type);

            //DamageDetails damageDetails = new DamageDetails()
            //{
            //    TypeEffectiveness = enemyType,
            //    Critical = critical,
            //    Death = false,
            //};
            //float modifiers = Random.Range(0.85f, 1f) * enemyType * critical;
            //float damageValue = ability.AbilityBase.AbilityPower * (currentAttackDamage / currentDefense);

            //int damageOutput = Mathf.FloorToInt(damageValue * modifiers);//Final dmg value rounded to int.

            //currentAttack -> damageOutput
            damageable.OnTakeDamage(currentAttackDamage, knockbackEffect);

            //clears dotween effect
            transform.DOKill();
            //change color
            damageable.GetComponent<SpriteRenderer>().color = Color.cyan;
            damageable.GetComponent<SpriteRenderer>().DOColor(Color.red, .5f).From();

            //var enemyPos = playerCollider.transform.DOShakePosition(duration, strength);

            var enemyRot = playerCollider.transform.DOShakeRotation(duration, strength);

            playerCollider.transform.localScale = Vector3.one;
            var enemyScale = playerCollider.transform.DOShakeScale(duration, strength);
            if (enemyScale.IsPlaying()) return;

            Debug.Log("Damage from Slime");
        }

    }


    private void ElementStatsVariation()
    {
        //if (currentType == enemyBase.Type)
        //{
        //    currentType = ElementType.Fire
        //    if (targetCollider.CompareTag("Player"))
        //    {
        //        //effect on player
        //    }
        //    else if (targetCollider.CompareTag("Enemy"))
        //    {
        //        Debug.Log("Player Fire advantage");
        //    }
        //}
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

    public class DamageDetails
    {
        public bool Death { get; set; }
        public float Critical { get; set; }
        public float TypeEffectiveness { get; set; }


    }
}
