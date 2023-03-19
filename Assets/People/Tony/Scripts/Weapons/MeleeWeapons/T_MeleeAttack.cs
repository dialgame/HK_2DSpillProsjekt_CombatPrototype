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
    Vector3 direction;

  //  [SerializeField] float attackInterval;//Same as AttackInterval
  //  float readyForNextAttack = 0;

  //  public Collider2D weaponCollider;
   // public SpriteRenderer weaponSprite;

   // public bool isAttacking = false;
    //private bool enemyInRange = false;
    public Animator weaponAnimator;
    public static T_MeleeAttack instance;
    //T_MeleeHit meleeHit;



    [Header("Combo Settings")]
    [SerializeField] private float comboTimeWindow = 1f; // The time window in which the combo can be triggered
    [SerializeField] private int comboLength = 3; // The number of clicks required to trigger the combo
    //[SerializeField] private float clickCooldown; //Time that needs to pass before the next combo phase can be triggered. Not relevant anymore, keeping it just in case.

    [Header("Click Cooldowns")]
    [SerializeField] private float secondClickCooldown = 0.5f; // Time that needs to pass before the second combo phase can be triggered
    [SerializeField] private float thirdClickCooldown = 0.7f; // Time that needs to pass before the third combo phase can be triggered
    [SerializeField] private float comboResetCooldown = 1f; // Time 

    [Header("Is enemy in range?")]
    public bool enemyInRange;

    private float lastClickTime;
    private float lastComboTriggerTime;
    public int comboClickCount;
    public ComboState comboState = ComboState.Idle;

    [Header("Visual Damage Numbers")]
    public GameObject firstDmg;
    public GameObject secondDmg;
    public GameObject thirdDmg;


    public enum ComboState
    {
        Idle,
        FirstClick,
        SecondClick,
        ThirdClick
    }


    private void Awake()
    {
        currentWeaponDamage = weaponBase.WeaponDamage;
        currentWeaponSpeed = weaponBase.WeaponSpeed;
        instance = this;

        firstDmg.SetActive(false);
        secondDmg.SetActive(false);
        thirdDmg.SetActive(false);
        weaponAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)player.transform.position;
        FaceMouse();


            float currentTime = Time.time;

            // Determine which phase of the combo we are currently in. This allows for different cooldowns between each hit in the combo.
            float clickCooldown = 0f;
            switch (comboState)
            {
                case ComboState.FirstClick:
                    clickCooldown = secondClickCooldown;
                    break;
                case ComboState.SecondClick:
                    clickCooldown = thirdClickCooldown;
                    break;
                case ComboState.ThirdClick:
                    clickCooldown = comboResetCooldown;
                    break;
                default:
                    clickCooldown = 0f;
                    break;
            }


            if (currentTime - lastComboTriggerTime > clickCooldown)
            {
                if (currentTime - lastClickTime < comboTimeWindow)
                {
                    comboClickCount++;
                }
                else
                {
                    comboClickCount = 1;
                    comboState = ComboState.FirstClick;
                    weaponAnimator.Play("Base Layer.ATK1", 0, 0);

                    lastComboTriggerTime = currentTime;

                   // Debug.Log("START COMBO, previous combo wasnt maxed OR this NEW combo isn't started instantly after previous combo");

                    if (enemyInRange)
                    {

                        //Debug.Log("Enemy hit for 52 damage");
                        //thirdDmg.SetActive(false);
                        //firstDmg.SetActive(true);

                    }
                }
            }

            lastClickTime = currentTime;

            if (comboClickCount == 2 && comboState == ComboState.FirstClick)
            {
                comboState = ComboState.SecondClick;
                weaponAnimator.Play("Base Layer.ATK2", 0, 0);

                //Debug.Log("SECONDHIT");

                lastComboTriggerTime = currentTime;

                if (enemyInRange)
                {
                    //Debug.Log("Enemy hit for 61 damage");
                  //  firstDmg.SetActive(false);
                    //secondDmg.SetActive(true);
                }

            }
            else if (comboClickCount == 3 && comboState == ComboState.SecondClick)
            {
                comboState = ComboState.ThirdClick;
                weaponAnimator.Play("Base Layer.ATK3", 0, 0);

               // Debug.Log("THIRDHIT");

                lastComboTriggerTime = currentTime;

                if (enemyInRange)
                {

                   // Debug.Log("Enemy hit for 96 damage");
                  //  secondDmg.SetActive(false);
                  //  thirdDmg.SetActive(true);
                }
            }

            else if (comboClickCount > comboLength || comboState == ComboState.Idle)
            {

                comboClickCount = 1;
                comboState = ComboState.FirstClick;
                weaponAnimator.Play("Base Layer.ATK1", 0, 0);

                lastComboTriggerTime = currentTime;

                //Debug.Log("NEW COMBO");

                if (enemyInRange)
                {
                   // Debug.Log("Enemy hit for 52 damage");
                  //  thirdDmg.SetActive(false);
                   // firstDmg.SetActive(true);
                }
            }
        }
    }

    //Detects sword hitbox collision from child object

    public void CollisionDetected(T_MeleeHit meleeHit)
    {
        enemyInRange = true;
        Debug.Log("detected");
    }

    public void CollisionExit(T_MeleeHit meleeHit)
    {
        enemyInRange = false;
        Debug.Log("collision exit");
    }
    private void FaceMouse()
    {
        player.transform.right = direction;
    }
}
