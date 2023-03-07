using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMana : MonoBehaviour
{
    public int maxMana = 10;
    public int currentMana;

    public ManaBar manaBar;

    private void Start()
    {
        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ManaUsed(2);
        }
    }

    void ManaUsed(int damage)
    {
        currentMana -= damage;

        manaBar.SetHealth(currentMana);
    }
}
