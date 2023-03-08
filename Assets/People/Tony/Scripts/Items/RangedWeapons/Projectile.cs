using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] T_WeaponBaseSO weaponBase;

    [SerializeField] float timeToDestroy = 3;
    Rigidbody2D rb2d;
    [SerializeField] Collider2D projectileCollider;

    [HideInInspector] public int currentWeaponDamage;

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
        Collider2D enemyCollider = collision.gameObject.GetComponent<Collider2D>();
        T_EnemyStats damageableObject = collision.GetComponent<T_EnemyStats>();

        if (damageableObject != null)
        {
            Vector2 direction = (enemyCollider.transform.position - transform.position).normalized;
            Vector2 knockbackEffect = direction * weaponBase.KnockbackForce;

            damageableObject.OnTakeDamage(weaponBase.WeaponDamage, knockbackEffect);
            Debug.Log(weaponBase.WeaponDamage);
        }
    }
}
