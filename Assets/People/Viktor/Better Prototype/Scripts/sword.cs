using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sword : MonoBehaviour
{
    //Try and make this but without an instantiating prefab collider. Could be an invisible gameobject that turns collider on and off. Pretty sure it will make all of this a whole lot easier.
    public Animator myAnim;
    


    // Start is called before the first frame update
    void Start()
    {
        
        
       

    }

   

    private void OnTriggerEnter2D(Collider2D other)
    {

        
        if (other.gameObject.tag == "Enemy")
        {
            //Destroy(other.gameObject);

            transform.parent.GetComponent<SwordSlash>().CollisionDetected(this);
          
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {


        if (other.gameObject.tag == "Enemy")
        {
            //Destroy(other.gameObject);

            transform.parent.GetComponent<SwordSlash>().CollisionExit(this);
        }
    }



}
