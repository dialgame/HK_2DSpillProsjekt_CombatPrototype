using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Explosion : MonoBehaviour
{
    Collider2D[] inExplosionRadius = null;
    [SerializeField] private float ExplosionForceMulti = 5;
    [SerializeField] private float ExplosionRadius = 5;

    public GameObject Player;
    

    float cooldown;

    private void Start()
    {
        Player = GameObject.Find("player"); //Assign game object on game start. Because you can't add a non prefab to a prefab
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Explode();
    }

    void Explode()
    {
        
        print("ExploStart");
        inExplosionRadius = Physics2D.OverlapCircleAll(transform.position, ExplosionRadius); //Checks if there are colliders in a circle

        foreach (Collider2D o in inExplosionRadius) //For each of the colliders in the radius we will check if it has RigidBody attached to it
        {
            print("PlayerDetected"); //Doesnt detect player collider?
            Rigidbody2D o_rigidbody = o.GetComponent<Rigidbody2D>();


            if (o_rigidbody != null)
            {
                
                Vector2 distanceVector = o.transform.position - transform.position;
                if (distanceVector.magnitude > 0) //To avoid NaN error, a nice tip is to not divide by 0
                {
                    Player.GetComponent<Movement>().enabled = false; //Nice way to connect scripts. Also disables player movement script to avoid bullshit.
                    float explosionForce = ExplosionForceMulti / distanceVector.magnitude;
                    o_rigidbody.AddForce(distanceVector.normalized * explosionForce);
                    Invoke(nameof(ResetControls), 0.2f);
                }
            }
        }          


    
    }

    private void ResetControls()
    {
        Player.GetComponent<Movement>().enabled = true;
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius); //Draws radius circle. Gizmos are fantastic for debugging.
    }

}
