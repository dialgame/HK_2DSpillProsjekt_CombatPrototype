using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Enemy_DetectionZone : MonoBehaviour
{
    public string tagTarget = "Player";
    public List<Collider2D> detectedObjects = new List<Collider2D>();
    [SerializeField] Collider2D collider2d;

    //Detect when player enters range
    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if(playerCollider.gameObject.tag == tagTarget)
        {
            detectedObjects.Add(playerCollider);
        }   
    }

    private void OnTriggerExit2D(Collider2D playerCollider)
    {
        if(playerCollider.gameObject.tag == tagTarget)
        {
            detectedObjects.Remove(playerCollider);
        }
    }
}
