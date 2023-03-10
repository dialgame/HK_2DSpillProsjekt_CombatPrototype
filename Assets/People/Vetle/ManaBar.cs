using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{

    float lerpSpeed;
    public int maxMana = 10;
    public int minMana = 0;
    public int currentMana;
    public int usageNumber = 5;

    public Slider slider;

    private void Start()
    {
        currentMana = maxMana;
        SetMaxMana();
    }

    private void Update()
    {
        if (currentMana > maxMana) currentMana = maxMana;
        if (currentMana < minMana) currentMana = minMana;
        lerpSpeed = 3f * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DamageTaken(usageNumber);
        }
    }

    private void DamageTaken(int usage)
    {
        currentMana -= usage;
        SetMana();
    }

    public void SetMaxMana()
    {
        slider.maxValue = maxMana;
        //slider.value = health;
    }
    public void SetMana()
    {
        slider.value = currentMana;
        //float sliderValue = currentHealth / maxHealth;
        //slider.value = Mathf.Lerp(slider.value, damageNumber, lerpSpeed);
    }
}
