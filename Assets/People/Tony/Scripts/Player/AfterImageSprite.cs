using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImageSprite : MonoBehaviour
{
    private Transform player;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer playerSR;

    private Color color;

    private float activeTime = 0.1f;
    private float timeActivated;
    private float alphaValue; //keeps track of what value it is at
    private float alphaSet = 0.8f; //this value when gameobject gets enabled
    [SerializeField] private float alphaMultiplier = 0.85f; //the smaller the number, the faster the sprite will fade

    private void OnEnable()
    {
        //can use OnEnable for the bugs we have???
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform; 
        playerSR = player.GetComponent<SpriteRenderer>();

        alphaValue = alphaSet;
        spriteRenderer.sprite = playerSR.sprite;

        transform.position = player.position;
        transform.rotation = player.rotation;
        timeActivated = Time.time;
    }

    private void Update()
    {
        alphaValue *= alphaMultiplier; //updates alphaValue after each multiple
        color = new Color(1f, 1f, 1f, alphaValue); //declares color value
        spriteRenderer.color = color;// sprite uses the multiplied color with alphaValue

        if(Time.time >= (timeActivated + activeTime))
        {
            AfterImagePool.Instance.AddToPool(gameObject);//this adds to the pool INSTEAD of destroying the gameObject.
        }
    }
}
