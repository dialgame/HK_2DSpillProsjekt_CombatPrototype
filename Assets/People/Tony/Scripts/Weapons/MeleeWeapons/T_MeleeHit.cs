using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class T_MeleeHit : MonoBehaviour
{
    [SerializeField] T_WeaponBaseSO weaponBase;
    [HideInInspector] public int currentWeaponDamage;
    //[SerializeField] Animator swordAnimator;

    //public Collider2D swordCollider;

    [SerializeField] private ElementTypes weaponElementType; //declare which element it is in the SO
    [SerializeField] T_MeleeAttack meleeAttack;

    [SerializeField] float duration;
    [SerializeField] float strength;

    private void Awake()
    {
        currentWeaponDamage = weaponBase.WeaponDamage;
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Collider2D enemyCollider = collision.gameObject.GetComponent<Collider2D>();
        T_EnemyStats damageableObject = collision.GetComponent<T_EnemyStats>();


        if (damageableObject != null && meleeAttack.comboClickCount == 1)
        {
            transform.parent.GetComponent<T_MeleeAttack>().CollisionDetected(this);

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
           // Debug.Log("First HIT!");

            damageableObject.DOKill();
            damageableObject.GetComponent<SpriteRenderer>().color = Color.white;
            damageableObject.GetComponent<SpriteRenderer>().DOColor(Color.red, .5f).From();

            var enemyRot = collision.transform.DOShakeRotation(duration, strength);

            collision.transform.localScale = Vector3.one;
            var enemyScale = collision.transform.DOShakeScale(duration, strength);
            if (enemyScale.IsPlaying()) return;
            damageableObject.DOComplete();


        }

        else if(damageableObject != null && meleeAttack.comboClickCount == 2)
        {
            transform.parent.GetComponent<T_MeleeAttack>().CollisionDetected(this);

            Vector2 direction = (enemyCollider.transform.position - transform.position).normalized;
            Vector2 knockbackEffect = direction * weaponBase.KnockbackForce;

            //modifiers, can add more if neccessary
            float critical = 1f;
            if (Random.value * 100f <= 3f) // 3% crit rate
            {
                critical = 2f;
            }

            float modifiers = Random.Range(0.85f, 1f) * critical;
            float damageValue = (currentWeaponDamage / damageableObject.currentDefense);        //(weapondmg/enemyDefense)  
            
            //2-chain modifier
            float comboModifier = Random.Range(0.85f, 1f) * 1.25f;

            int damageOutput = Mathf.FloorToInt(damageValue * modifiers * comboModifier);//Final dmg value rounded to int.

            damageableObject.OnTakeDamage(damageOutput, knockbackEffect, weaponElementType);
           // Debug.Log("Second HIT!");

            damageableObject.DOKill();
            damageableObject.GetComponent<SpriteRenderer>().color = Color.white;
            damageableObject.GetComponent<SpriteRenderer>().DOColor(Color.red, .5f).From();

            var enemyRot = collision.transform.DOShakeRotation(duration, strength);

            collision.transform.localScale = Vector3.one;
            var enemyScale = collision.transform.DOShakeScale(duration, strength);
            if (enemyScale.IsPlaying()) return;
            damageableObject.DOComplete();

        }

        else if (damageableObject != null && meleeAttack.comboClickCount == 3)
        {
            transform.parent.GetComponent<T_MeleeAttack>().CollisionDetected(this);

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

            //3-chain modifier
            float comboModifier = Random.Range(0.85f, 1f) * 1.5f;

            int damageOutput = Mathf.FloorToInt(damageValue * modifiers * comboModifier);//Final dmg value rounded to int.

            damageableObject.OnTakeDamage(damageOutput, knockbackEffect, weaponElementType);
            Debug.Log("Third HIT!");

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

    private void OnTriggerExit2D(Collider2D other)
    {


        if (other != null)
        {
            //Destroy(other.gameObject);

            transform.parent.GetComponent<T_MeleeAttack>().CollisionExit(this);
        }
    }
}
