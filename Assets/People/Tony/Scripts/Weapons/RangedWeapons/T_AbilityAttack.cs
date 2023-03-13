using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_AbilityAttack : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] T_WeaponBaseSO weaponBase;
    [HideInInspector] public int currentWeaponSpeed;

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform projectilePosition;
    [SerializeField] float projectileFireRate;//Same as AttackInterval
    float readyForNextShot = 0;

    Vector3 direction;

    void Start()
    {
        currentWeaponSpeed = weaponBase.WeaponSpeed;
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)player.transform.position;
        //DirectionChecker(direction);
        FaceMouse();
        if (Input.GetMouseButtonDown(1))
        {
            if(Time.time  > readyForNextShot)
            {
                readyForNextShot = Time.time + 1 / projectileFireRate;
                OnFire();
            }
        }
    }
    private void FaceMouse()
    {
        player.transform.right = direction;
    }
    public void OnFire()
    {
        GameObject projectileInstantiate = Instantiate(projectilePrefab, projectilePosition.position, projectilePosition.rotation);
        projectileInstantiate.GetComponent<Rigidbody2D>().AddForce(projectileInstantiate.transform.right * currentWeaponSpeed);
    }

    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;
        float dirX = direction.x;
        float dirY = direction.y;

        Vector3 rotation = transform.rotation.eulerAngles;

        if (dirX < 0 && dirY == 0) //left
        {
            rotation.y = -180;
        }
        else if (dirX == 0 && dirY > 0)//up
        {
            rotation.z = 45;

        }
        else if (dirX == 0 && dirY < 0)//down
        {
            rotation.z = -135;

        }
        else if (dirX > 0 && dirY > 0)//Right Up
        {
            rotation.z = 0;
        }
        else if (dirX > 0 && dirY < 0)//Right Down
        {
            rotation.z = -90;
        }
        else if (dirX < 0 && dirY > 0)//Left Up
        {
            rotation.z = 90;
        }
        else if (dirX < 0 && dirY < 0)//Left Down
        {
            rotation.z = 180;
        }

        transform.localRotation = Quaternion.Euler(rotation);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    T_IDamageable damageableObject = collision.GetComponent<T_IDamageable>();
    //    if (collision.CompareTag("Enemy"))
    //    {
    //        //Calculate direction between character and slime
    //        Vector3 parentPosition = transform.parent.position;

    //        //Offset for collision detection changes the direction where the force comes from (close to the player)
    //        Vector2 direction = (collision.transform.position - parentPosition).normalized;

    //        //Knockbak is in direction of swordCollider towards collider
    //        Vector2 knockback = direction * weaponBase.KnockbackForce ;

    //        //after making sure the collider has a script that implements IDamageable, we can run the OnHit implementation and pas our Vector2 force
    //        damageableObject.OnTakeDamage(currentWeaponDamage, knockback);
    //    }
    //    //else if (collision.CompareTag("Props"))
    //    //{
    //    //    if(collision.gameObject.TryGetComponent(out BreakableProps breakable))
    //    //    {
    //    //        breakable.OnTakeDamage(currentWeaponDamage);
    //    //    }
    //    //}
    //}



}
