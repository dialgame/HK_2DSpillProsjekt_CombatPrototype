using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class AbilityProjectile : MonoBehaviour
{
    [SerializeField] T_WeaponBaseSO weaponBase;
    [HideInInspector] public int currentWeaponDamage;
    [SerializeField] float timeToDestroy = 3;

    //Elemental variable
    [SerializeField] T_AbilitySO abilitySO;
    [HideInInspector] public int currentAbilityPower;
    [SerializeField] private ElementTypes abilityElementType; //declare which element it is in the SO

    //DOTween variables
    [SerializeField] float duration;
    [SerializeField] float strength;

    private void Awake()
    {
        currentWeaponDamage = weaponBase.WeaponDamage;
        currentAbilityPower = abilitySO.AbilityPower;
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

            //modifiers, can add more if neccessary
            float critical = 1f;
            if (Random.value * 100f <= 6.25f)
            {
                critical = 2f;
            }

            float modifiers = Random.Range(0.85f, 1f) * critical;
            float damageValue = currentAbilityPower * (currentWeaponDamage / damageableObject.currentDefense);        // abilityDamage * (weapondmg/enemyDefense)  

            int damageOutput = Mathf.FloorToInt(damageValue * modifiers);//Final dmg value rounded to int.

            damageableObject.OnTakeDamage(damageOutput, knockbackEffect, abilityElementType); 
         
            Destroy(gameObject);

            damageableObject.DOKill();
            damageableObject.GetComponent<SpriteRenderer>().color = Color.white;
            damageableObject.GetComponent<SpriteRenderer>().DOColor(Color.red, .5f).From();

            var enemyRot = collision.transform.DOShakeRotation(duration, strength);

            collision.transform.localScale = Vector3.one;
            var enemyScale = collision.transform.DOShakeScale(duration, strength);
            if (enemyScale.IsPlaying()) return;
            damageableObject.DOComplete();


        }
    }


}
