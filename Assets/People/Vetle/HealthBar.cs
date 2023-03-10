using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //public float minimum;

    //public Image mask;
    //public Image fill;

    //public float maximumHealth = 100f;
    //public float currentHealth;

    float lerpSpeed;
    public int maxHealth = 10;
    public int minHealth = 0;
    public int currentHealth;
    public int damageNumber = 5;

    public Slider slider;

    private void Start()
    {
        currentHealth = maxHealth;
        SetMaxHealth();
    }

    private void Update()
    {
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        if (currentHealth < minHealth) currentHealth = minHealth;
        lerpSpeed = 3f * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DamageTaken(damageNumber);
        }
    }

    private void DamageTaken(int damage)
    {
        currentHealth -= damage;
        SetHealth();
    }

    public void SetMaxHealth()
    {
        slider.maxValue = maxHealth;
        //slider.value = health;
    }
    public void SetHealth()
    {
        slider.value = currentHealth;
        //float sliderValue = currentHealth / maxHealth;
        //slider.value = Mathf.Lerp(slider.value, damageNumber, lerpSpeed);
    }

    // void Update()
    //  {
    //  currentHealth = Mathf.Clamp(currentHealth, 0, maximumHealth);
    //  if (currentHealth > maximumHealth) currentHealth = maximumHealth;

    // GetCurrentFill();
    // if (Input.GetKeyDown(KeyCode.Space))
    // {
    // TakeDamage(5);
    // }
    // }

    // private void GetCurrentFill()
    // {
    //float currentOffset = currentHealth - minimum;
    //float maximumOffset = maximumHealth - minimum;

    // float fillAmount = currentOffset / maximumOffset;
    // mask.fillAmount = Mathf.Lerp(mask.fillAmount, fillAmount, lerpSpeed);
    // }

    //public void TakeDamage(float damage)
    // {
    //currentHealth -= damage;
    //}
}
