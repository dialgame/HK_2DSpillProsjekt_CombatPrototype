using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordSlash : MonoBehaviour
{

    public GameObject swordSlash;

    public float bulletSpeed;
    public GameObject bazooka;

    public bool enemyInRange;

    float cooldown;



    public Animator myAnim;
    public bool isAttacking = false;

    public SpriteRenderer sr;

    public static SwordSlash instance;


    public GameObject firstDmg;
    public GameObject secondDmg;
    public GameObject thirdDmg;
    public GameObject fourthDmg;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        myAnim = GetComponent<Animator>();
        enemyInRange = false;

        firstDmg.SetActive(false);
        secondDmg.SetActive(false);
        thirdDmg.SetActive(false);
        fourthDmg.SetActive(false);
    }


    void Update()
    {
        Attack();

    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isAttacking)
        {
            isAttacking = true; //Starts animation cycle
            Slash();
            
        }

        cooldown -= Time.deltaTime;
    }

    private void Slash()
    {
        if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && enemyInRange) //Potentially need to fix this. Animation state is a bit off on first hit
        {
            Debug.Log("51 damage");
            firstDmg.SetActive(true);
        }

        if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack 1") && enemyInRange)
            {
                Debug.Log("52 damage");
            firstDmg.SetActive(false);
            secondDmg.SetActive(true);
            
        }

            if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack 2") && enemyInRange)
            {
                Debug.Log("56 damage");
            thirdDmg.SetActive(true);
            secondDmg.SetActive(false);
        }

            if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack 3") && enemyInRange)
            {
                Debug.Log("96 damage!!!");
            fourthDmg.SetActive(true);
            thirdDmg.SetActive(false);
        }              


    }


    


    public void CollisionDetected(sword sword) //not allowed to call this function
    {
        enemyInRange = true;
        Debug.Log("detected");


        //Destroy(other.gameObject);     
    }

    public void CollisionExit(sword sword) //not allowed to call this function
    {
        enemyInRange = false;
        Debug.Log("collision exit");


        //Destroy(other.gameObject);     
    }

}

