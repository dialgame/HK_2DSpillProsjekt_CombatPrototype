using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class AbilityProjectile : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] T_WeaponBaseSO weaponBase;

    [SerializeField] float timeToDestroy = 3;
    [SerializeField] Collider2D projectileCollider;

    [HideInInspector] public int currentWeaponDamage;

    //DOTween variables
    [SerializeField] float duration;
    [SerializeField] float strength;

    //Elemental variable
    T_PlayerStats playerStats;
    T_EnemyBase enemyBase;
    [SerializeField] T_AbilitySO abilitySO;
    [HideInInspector] public int currentAbilityPower;
    [HideInInspector] public ElementType currentElementType;
    //[SerializeField] ElementType elementType;
 

    private void Awake()
    {
        enemyBase = FindObjectOfType<T_EnemyBase>();
        currentWeaponDamage = weaponBase.WeaponDamage;
        currentAbilityPower = abilitySO.AbilityPower;
        currentElementType = abilitySO.AbilityType;
    }
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Collider2D enemyCollider = collision.gameObject.GetComponent<Collider2D>();
        T_EnemyStats damageableObject = collision.GetComponent<T_EnemyStats>();
        

        if (damageableObject != null)
        {
            Vector2 direction = (enemyCollider.transform.position - transform.position).normalized;
            Vector2 knockbackEffect = direction * weaponBase.KnockbackForce;

            //////attack test!
            //float critical = 1f;
            //if (Random.value * 100f <= 6.25f)
            //{
            //    critical = 2f;
            //}

            //T_AbilitySO damageDetails = new T_AbilitySO()
            //{
            //    TypeEffectiveness = typeDifference,
            //    //Critical = critical,
            //    //Death = false,
            //};
            float typeDifference = TypeChart.TypeEffectiveness(currentElementType, damageableObject.currentEnemyType); //magic element type vs enemy element type

            float modifiers = typeDifference; //Random.Range(0.85f, 1f) * 
            float damageValue = currentAbilityPower * (currentWeaponDamage / damageableObject.currentDefense); // magicDamage * (weapondmg/enemyDefense)

            int damageOutput = Mathf.FloorToInt(damageValue * modifiers);//Final dmg value rounded to int.

            damageableObject.OnTakeDamage(damageOutput, knockbackEffect); //weaponBase.WeaponDamage
            Debug.Log(damageOutput);
            Destroy(gameObject);

            //damageableObject.DOKill();
            //damageableObject.GetComponent<SpriteRenderer>().color = Color.red;
            //damageableObject.GetComponent<SpriteRenderer>().DOColor(Color.gray, .5f).From();
                   
            ////var enemyPos = collision.transform.DOShakePosition(duration, strength);

            //var enemyRot = collision.transform.DOShakeRotation(duration, strength);

            //collision.transform.localScale = Vector3.one;
            //var enemyScale = collision.transform.DOShakeScale(duration, strength);
            //if (enemyScale.IsPlaying()) return;

            ////Sets collider target to a chosen ElementState. How?
            ////elementStates.targetCollider = enemyCollider;

        }
    }


}
