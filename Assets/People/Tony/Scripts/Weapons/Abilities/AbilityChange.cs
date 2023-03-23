using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityChange : MonoBehaviour
{

    int totalAbilities;//know the total current available weapons
    public int currentAbilityIndex;//to know which weapon im equipping

    [SerializeField] GameObject[] abilities;
    [SerializeField] GameObject abilityHolder;
    [SerializeField] GameObject currentAbility;

    [SerializeField] private GameObject thunderCast;
    [SerializeField] private GameObject rotatePoint;

    [SerializeField] Transform currentPosition;
    [SerializeField] Transform previousPosition;

    bool isAvailable;//if player has it
    int cooldownTimer;


    void Start()
    {
        totalAbilities = abilityHolder.transform.childCount;
        abilities = new GameObject[totalAbilities];

        for (int i = 0; i < totalAbilities; i++)
        {
            abilities[i] = abilityHolder.transform.GetChild(i).gameObject;
            abilities[i].SetActive(false);
        }

        abilities[0].SetActive(true);
        currentAbility = abilities[0];
        currentAbilityIndex = 0;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (currentAbilityIndex != 0)
            {
                abilities[currentAbilityIndex].SetActive(false);
                currentAbilityIndex = 0;
                abilities[currentAbilityIndex].SetActive(true);

                currentAbility = abilities[currentAbilityIndex];
            }
            Debug.Log("Key pressed");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (currentAbilityIndex != 1)
            {
                abilities[currentAbilityIndex].SetActive(false);
                currentAbilityIndex = 1;
                abilities[currentAbilityIndex].SetActive(true);

                currentAbility = abilities[currentAbilityIndex];

                rotatePoint.SetActive(false);
                thunderCast.SetActive(true);
                
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (currentAbilityIndex != 2)
            {
                abilities[currentAbilityIndex].SetActive(false);
                currentAbilityIndex = 2;
                abilities[currentAbilityIndex].SetActive(true);

                currentAbility = abilities[currentAbilityIndex];
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (currentAbilityIndex != 3)
            {
                abilities[currentAbilityIndex].SetActive(false);
                currentAbilityIndex = 3;
                abilities[currentAbilityIndex].SetActive(true);

                currentAbility = abilities[currentAbilityIndex];
            }
        }

    }
}
