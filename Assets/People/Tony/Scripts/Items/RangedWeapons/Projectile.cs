using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] T_WeaponBaseSO weaponBase;

    [SerializeField] float timeToDestroy = 3;
    [SerializeField] Collider2D projectileCollider;

    [HideInInspector] public int currentWeaponDamage;

    //DOTween variables
    [SerializeField] float duration;
    [SerializeField] float strength;

    private void Awake()
    {
        currentWeaponDamage = weaponBase.WeaponDamage;
    }
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transform enemyObject = collision.GetComponent<Transform>();
        Collider2D enemyCollider = collision.gameObject.GetComponent<Collider2D>();
        T_EnemyStats damageableObject = collision.GetComponent<T_EnemyStats>();

        if (damageableObject != null)
        {
            Vector2 direction = (enemyCollider.transform.position - transform.position).normalized;
            Vector2 knockbackEffect = direction * weaponBase.KnockbackForce;

            damageableObject.OnTakeDamage(weaponBase.WeaponDamage, knockbackEffect);
            Destroy(gameObject);

            //reset variables after tweening?
            transform.DOComplete();

            var enemyPos = collision.transform.DOShakePosition(duration, strength);

            var enemyRot = collision.transform.DOShakeRotation(duration, strength); 
            
            var enemyScale = collision.transform.DOShakeScale(duration, strength);
            if (enemyScale.IsPlaying()) return;

            transform.DOKill();


            Debug.Log(weaponBase.WeaponDamage);
        }
    }


}
