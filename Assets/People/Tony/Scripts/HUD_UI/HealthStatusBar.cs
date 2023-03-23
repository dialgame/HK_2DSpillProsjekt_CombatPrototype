using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class HealthStatusBar : MonoBehaviour
{
    [SerializeField] T_PlayerStats playerStats;
    [SerializeField] T_PlayerBase playerBase;
    public Image fillbar;

    //public float maxHealth; //max mana
    public float currentHealth; //current mana

    public float damageAmount = 10f; //manaCost
    public float healAmount = 10f; //manaRefresh
    

   // public TextMeshProUGUI text;

    public bool shouldLerp = false;
    public float lerpSpeed = 2f;

    public Ease ease;

    private void Awake()
    {
        //currentHealth = maxHealth;
        currentHealth = playerBase.MaxHealth; // which leads to max health in player
        //text
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeHealth(damageAmount);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            ChangeHealth(-healAmount);
        }


    }


    public void ChangeHealth(float amount)
    {

        DOVirtual.Float(currentHealth, currentHealth - amount, lerpSpeed, LerpDamage).SetEase(ease);
    }

    private void LerpDamage(float value)
    {

        currentHealth = value;
        currentHealth = Mathf.Clamp(currentHealth, 0, playerBase.MaxHealth);

        fillbar.fillAmount = currentHealth / playerBase.MaxHealth;

        //text


    }

}
