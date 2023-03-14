using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;
    [SerializeField] private ElementResistanceSO elementResistance;

    private void Start()
    {
        currentHealth = maxHealth; 
    }
    public void DealDamage(int damage, ElementTypes elementType)
    {
        currentHealth -= elementResistance.CalculateDamageWithResistance(damage, elementType);
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
