using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    
    public List<Collider2D> detectedObjects = new List<Collider2D>();
    public Collider2D col;

    

    // Update is called once per frame
    void Update()
    {
        
    }

    //Detects when object enter range
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "player")
        {
            detectedObjects.Add(collider);
        }
        
    }

    //Detects when object leaves range

    private void OnTriggerExit2D(Collider2D collider)
    {
        detectedObjects.Remove(collider);
    }
}
