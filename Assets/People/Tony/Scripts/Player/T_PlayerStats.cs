using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_PlayerStats : MonoBehaviour, T_IDamageable
{
    [SerializeField] T_PlayerBase playerBase;
    [SerializeField] HealthStatusBar healthStatusBar;
    Rigidbody2D rb2d;
    Collider2D col2d;

    bool targetable = true;
    public bool disableSimulation = false;

    //Current stats
    public int currentHealth;
    public int currentMana;
                             
    [HideInInspector] public int currentMoveSpeed;
    [HideInInspector] public int currentAttackDamage;
    [HideInInspector] public float currentAttackSpeed;
                             
    [HideInInspector] public int currentDefense;
    [HideInInspector] public float currentMagnet;

    //Element variable
    [SerializeField] private ElementResistanceSO elementResistance;


    //I_Frames, invincibility time frame
    [Header("I-Frames")]
    [SerializeField] float invincibilityDuration;
    float invincbilityTimer;
    bool isInvincible = false;


    private void Awake()
    {
        currentHealth = playerBase.MaxHealth;
        currentMana = playerBase.MaxMana;
        currentMoveSpeed = playerBase.MoveSpeed;
        currentAttackDamage = playerBase.AttackDamage;
        currentAttackSpeed = playerBase.AttackSpeed;
        currentDefense = playerBase.Defense;
        currentMagnet = playerBase.Magnet;

        rb2d = GetComponent<Rigidbody2D>();
        col2d = GetComponent<Collider2D>();
    }
    private void Update()
    {
        
    }

    public void OnTakeDamage(Vector2 knockback, ElementTypes elementType)
    {
        rb2d.AddForce(knockback); //ForceMode2D.Impulse
        Debug.Log("Monster attacked you!");
    }

    public void OnTakeDamage(Vector2 knockback, ElementTypes elementType, int damage)
    {
        currentHealth -= elementResistance.CalculateDamageWithResistance(damage, elementType);

        Debug.Log(elementResistance.CalculateDamageWithResistance(damage, elementType));

        //apply force to the slime
        rb2d.AddForce(knockback); //ForceMode2D.Impulse
        if (currentHealth <= 0)
        {
            OnDeath();
        }
    }



    public void OnDeath()
    {
        //Make something flashy
        Debug.Log("Player died");
    }


    //property. Needed to specify target for Enemy.
    public bool IsTargetable
    {
        get { return targetable; }
        set
        {
            targetable = value;
            col2d.enabled = value;

            if (disableSimulation)//toggle
            {
                rb2d.simulated = false;//turns off physics when object dies.
            }
        }
    }
}
