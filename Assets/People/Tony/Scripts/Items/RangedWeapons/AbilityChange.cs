using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityChange : MonoBehaviour
{

    int totalWeapons;//know the total current available weapons
    public int currentWeaponIndex;//to know which weapon im equipping

    [SerializeField] GameObject[] weapons;
    [SerializeField] GameObject weaponHolder;
    [SerializeField] GameObject currentWeapon;

    [SerializeField] Transform currentPosition;
    [SerializeField] Transform previousPosition;

    bool isAvailable;//if player has it
    int cooldownTimer;


    void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        weapons = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            weapons[i] = weaponHolder.transform.GetChild(i).gameObject;
            weapons[i].SetActive(false);
        }

        weapons[0].SetActive(true);
        currentWeapon = weapons[0];
        currentWeaponIndex = 0;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (currentWeaponIndex != 0)
            {
                weapons[currentWeaponIndex].SetActive(false);
                currentWeaponIndex = 0;
                weapons[currentWeaponIndex].SetActive(true);

                currentWeapon = weapons[currentWeaponIndex];
            }
            Debug.Log("Key pressed");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (currentWeaponIndex != 1)
            {
                weapons[currentWeaponIndex].SetActive(false);
                currentWeaponIndex = 1;
                weapons[currentWeaponIndex].SetActive(true);

                currentWeapon = weapons[currentWeaponIndex];
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (currentWeaponIndex != 2)
            {
                weapons[currentWeaponIndex].SetActive(false);
                currentWeaponIndex = 2;
                weapons[currentWeaponIndex].SetActive(true);

                currentWeapon = weapons[currentWeaponIndex];
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (currentWeaponIndex != 3)
            {
                weapons[currentWeaponIndex].SetActive(false);
                currentWeaponIndex = 3;
                weapons[currentWeaponIndex].SetActive(true);

                currentWeapon = weapons[currentWeaponIndex];
            }
        }

    }
}
