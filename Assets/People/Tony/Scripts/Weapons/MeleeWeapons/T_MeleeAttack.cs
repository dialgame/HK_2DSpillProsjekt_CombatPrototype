using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_MeleeAttack : MonoBehaviour
{
    [SerializeField] Transform player;
    public T_PlayerMovement playerMovement;

    [SerializeField] T_WeaponBaseSO weaponBase;
    [HideInInspector] public int currentWeaponDamage;
    [HideInInspector] public int currentWeaponSpeed;

    [SerializeField] float attackInterval;//Same as AttackInterval
    float readyForNextAttack = 0;

    public Collider2D weaponCollider;
    public Animator weaponAnimator;
    public SpriteRenderer weaponSprite;

    public bool isAttacking = false;
    //private bool enemyInRange = false;
    public static T_MeleeAttack instance;
    int attackIndex = 4;

    Vector3 direction;
    private void Awake()
    {
        currentWeaponDamage = weaponBase.WeaponDamage;
        currentWeaponSpeed = weaponBase.WeaponSpeed;
        instance = this;
        weaponCollider.enabled = false;
    }
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)player.transform.position;
        //DirectionChecker(direction);
        FaceMouse();
        OnAttack();
    }
    private void OnAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > readyForNextAttack && !isAttacking)
            {
                //playerMovement.LockMovement();
                //weaponCollider.enabled = true;
                isAttacking = true;

                AttackChain();
                readyForNextAttack = Time.time + 1 / attackInterval;
            }
       

        }

        if (Input.GetMouseButtonUp(0))
        {
            if (Time.time < readyForNextAttack && isAttacking)
            {
                //playerMovement.UnlockMovement();
                //weaponCollider.enabled = false;
                isAttacking = false;

            }

        }
    }
    private void AttackChain()
    {
        switch (attackIndex)
        {
            //default:
            //    if (weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) //Potentially need to fix this. Animation state is a bit off on first hit
            //    {
            //        Debug.Log("1ST");
            //        //Debug.Log("51 damage");
            //        //firstDmg.SetActive(true);
            //    }
            //    break;
            //case 1:
            //case 2: 
            //case 3:
            //case 4:

        }
        //Use switch statements for meleehit?
        if (weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) //Potentially need to fix this. Animation state is a bit off on first hit
        {
            Debug.Log("1ST");
            //Debug.Log("51 damage");
            //firstDmg.SetActive(true);
        }

        if (weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack 1"))
        {
            Debug.Log("2ND");
            //firstDmg.SetActive(false);
            //secondDmg.SetActive(true);

        }

        if (weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack 2"))
        {
            Debug.Log("3RD");
            //thirdDmg.SetActive(true);
            //secondDmg.SetActive(false);
        }

        if (weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack 3"))
        {
            Debug.Log("FINAL");
            //fourthDmg.SetActive(true);
            //thirdDmg.SetActive(false);
        }
    }
    private void FaceMouse()
    {
        player.transform.right = direction;
    }
}
