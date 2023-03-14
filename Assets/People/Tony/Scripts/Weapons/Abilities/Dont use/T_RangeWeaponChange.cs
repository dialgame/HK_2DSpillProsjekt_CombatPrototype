using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_RangeWeaponChange : MonoBehaviour
{
    //[SerializeField] T_WeaponBaseSO weaponBase;

    int totalWeapons;//know the total current available weapons
    public int currentWeaponIndex;//to know which weapon im equipping

    [SerializeField] GameObject[] weapons;
    [SerializeField] GameObject weaponHolder;
    [SerializeField] GameObject currentWeapon;
    bool isAvailable;//if player has it


    void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        weapons = new GameObject[totalWeapons];//3

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            //next weapon
            if (currentWeaponIndex < totalWeapons - 1)
            {
                weapons[currentWeaponIndex].SetActive(false);
                currentWeaponIndex += 1;
                weapons[currentWeaponIndex].SetActive(true);

                currentWeapon = weapons[currentWeaponIndex];
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //prev weapon
            if (currentWeaponIndex > 0)
            {
                weapons[currentWeaponIndex].SetActive(false);
                currentWeaponIndex -= 1;
                weapons[currentWeaponIndex].SetActive(true);

                currentWeapon = weapons[currentWeaponIndex];
            }
        }
    }
   
}
