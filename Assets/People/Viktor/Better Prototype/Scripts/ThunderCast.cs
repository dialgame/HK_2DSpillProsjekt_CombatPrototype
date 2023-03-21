using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderCast : MonoBehaviour
{
    public GameObject aimPoint;
    public GameObject thunderSpell;

    public GameObject swordAiming;
    private void Update()
    {

        //GameObject that this script is attached to follows the mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        transform.position = mousePosition;
        

        if (Input.GetMouseButtonDown(0))
        {
            GameObject clone;
            clone = Instantiate(thunderSpell, aimPoint.transform.position, aimPoint.transform.rotation);

            gameObject.SetActive(false);
            swordAiming.SetActive(true);
            

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(false);
            swordAiming.SetActive(true);
        }



    }

    
}
