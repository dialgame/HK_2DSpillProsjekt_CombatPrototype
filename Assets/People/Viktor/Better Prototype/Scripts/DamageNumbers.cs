using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageNumbers : MonoBehaviour
{
    private const float DISAPPEAR_TIMER_MAX = 1f;

    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;
    private Vector3 moveVector;

    //Create a Damage Number Popup
    public static DamageNumbers Create(Vector3 position, int damageAmount, bool isCriticalHit)
    {
        Transform damageNumbersTransform = Instantiate(GameAssets.i.damageNumbersPopUp, position, Quaternion.identity ); //potentially vector3.zero instead of position
        DamageNumbers damageNumbers = damageNumbersTransform.GetComponent<DamageNumbers>();
        damageNumbers.Setup(damageAmount, isCriticalHit);

        return damageNumbers;
    }

    private static int sortingOrder;
    
    

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }


    public void Setup(int damageAmount, bool isCriticalHit) //this sets damage to print
    {
        textColor = Color.white;
        textMesh.SetText(damageAmount.ToString());
        if (!isCriticalHit)
        {
            //Normal hit
            textMesh.fontSize = 3;
            textColor = new Color32(255, 215, 35, 255);
        }
        else
        {
            //Critical hit
            textMesh.fontSize = 4;
            textColor = new Color32(204, 0, 204, 255);
        }
        
        textMesh.faceColor = textColor;
        disappearTimer = DISAPPEAR_TIMER_MAX;

        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;

        moveVector = new Vector3(5, 1) * 5f; // multiplied by speed
    }

    private void Update()
    {
        
        transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * 8f * Time.deltaTime;


        if (disappearTimer > DISAPPEAR_TIMER_MAX * .5f)
        {
            //first half of the popup lifetime
            float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;

        } else
        {
            //Second half of the popup lifetime
            float decreaseScaleAmount = 1f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            //Start disappearing
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;

            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }

        }
    }
}
