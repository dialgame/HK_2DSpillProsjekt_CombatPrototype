using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.VFX;

public class Lasersight : MonoBehaviour
{
    public GameObject spawnLaser;
    public LayerMask ground;
    [SerializeField]
    private LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
      lr = GetComponent<LineRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(spawnLaser.transform.position, spawnLaser.transform.right, ground);

        if(hit.collider != null)
        {
            
            Debug.DrawRay(spawnLaser.transform.position, spawnLaser.transform.right * hit.distance, Color.red);
            
            

        } else
        {
            
            Debug.DrawRay(spawnLaser.transform.position, spawnLaser.transform.right * 15, Color.red);
            
        }

        
    }
}
