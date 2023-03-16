using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class T_MeleeHit : MonoBehaviour
{
    [SerializeField] T_WeaponBaseSO weaponBase;
    [HideInInspector] public int currentWeaponDamage;

    //Collider2D weaponCollider;

    //public bool isAttacking = false;
    //private bool enemyInRange = false;
    //public static T_MeleeAttack instance;
    //float attackCooldown;

    //Elemental variable
    [SerializeField] private ElementTypes weaponElementType; //declare which element it is in the SO



    //DOTween variables
    [SerializeField] float duration;
    [SerializeField] float strength;

    private void Awake()
    {
        currentWeaponDamage = weaponBase.WeaponDamage;
        //instance = this;
        //weaponCollider = GetComponent<Collider2D>();
        //weaponCollider.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Attack();
    }
    //void Attack()
    //{
    //    if (Input.GetKeyDown(KeyCode.Mouse0) && !isAttacking)
    //    {
    //        weaponCollider.enabled = true;
    //        isAttacking = true; //Starts animation cycle
    //        //Slash();
    //    }
    //    else
    //    {
    //        weaponCollider.enabled = false;
    //        isAttacking = false;
    //    }

    //    //attackCooldown -= Time.deltaTime;
    //}

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
            float damageValue = (currentWeaponDamage / damageableObject.currentDefense);        //(weapondmg/enemyDefense)  

            int damageOutput = Mathf.FloorToInt(damageValue * modifiers);//Final dmg value rounded to int.

            damageableObject.OnTakeDamage(damageOutput, knockbackEffect, weaponElementType);

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
