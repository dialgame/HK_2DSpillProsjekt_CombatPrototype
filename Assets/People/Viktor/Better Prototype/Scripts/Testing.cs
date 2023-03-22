using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{

    
    
   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            bool isCriticalHit = Random.Range(0, 100) < 30;
            //DamageNumbers.Create(Vector3.zero, 300, isCriticalHit);
        }
    }

}
