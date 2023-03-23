//using UnityEngine;


//public class EnemyController : MonoBehaviour
//{
//    public enum MoveSetType { Overworld, Combat }

//    public float moveSpeed = 5f;
//    public int maxHealth = 100;
//    public int currentHealth;
//    public GameObject damageEffect;
//    public GameObject deathEffect;
//    public AudioClip hitSound;
//    public AudioClip deathSound;
//    public float hitVolume = 1f;
//    public float deathVolume = 1f;

//    private Rigidbody2D rb;
//    private Animator anim;
//    private AudioSource audioSource;

//    public EnemyMoveSet overworldMoveSet;
//    public EnemyMoveSet combatMoveSet;
//    private EnemyMoveSet currentMoveSet;


//    // Move sets for overworld and combat
//    //public EnemyMoveSet overworldMoveSet;
//    //public EnemyMoveSet combatMoveSet;


//    public void SetMoveSet(EnemyMoveSet moveSet)
//    {
//        // Disable all move sets
//        overworldMoveSet.enabled = false;
//        combatMoveSet.enabled = false;

//        // Enable the specified move set
//        moveSet.enabled = true;
//    }


//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        anim = GetComponent<Animator>();
//        audioSource = GetComponent<AudioSource>();

//        currentHealth = maxHealth;
//        currentMoveSet = overworldMoveSet;
//    }

//    void Update()
//    {
//        if (currentMoveSet == null)
//        {
//            return;
//        }

//        Vector2 movement = currentMoveSet.GetMovement();

//        rb.velocity = movement * moveSpeed;
//        anim.SetFloat("Horizontal", movement.x);
//        anim.SetFloat("Vertical", movement.y);
//        anim.SetFloat("Speed", movement.magnitude);
//    }

//    public void TakeDamage(int damage)
//    {
//        currentHealth -= damage;
//        audioSource.PlayOneShot(hitSound, hitVolume);
//        Instantiate(damageEffect, transform.position, Quaternion.identity);

//        if (currentHealth <= 0)
//        {
//            Die();
//        }
//    }

//    void Die()
//    {
//        audioSource.PlayOneShot(deathSound, deathVolume);
//        Instantiate(deathEffect, transform.position, Quaternion.identity);
//        Destroy(gameObject);
//    }

//    public void SetMoveSet(MoveSetType moveSetType)
//    {
//        switch (moveSetType)
//        {
//            case MoveSetType.Overworld:
//                currentMoveSet = overworldMoveSet;
//                break;
//            case MoveSetType.Combat:
//                currentMoveSet = combatMoveSet;
//                break;
//        }
//    }
//}
//using UnityEngine;

//public class EnemyController : MonoBehaviour
//{


//}
