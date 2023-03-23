//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    public float moveSpeed = 5f;
//    public GameObject combatUI;

//    private Vector2 movement;
//    private bool inCombat;

//    private Rigidbody2D rb;

//    private void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        inCombat = false;
//    }

//    private void Update()
//    {
//        if (!inCombat)
//        {
//            // Get input for movement in the overworld
//            movement.x = Input.GetAxisRaw("Horizontal");
//            movement.y = Input.GetAxisRaw("Vertical");
//        }
//        else
//        {
//            // Disable movement during combat
//            movement = Vector2.zero;
//        }

//        // Toggle combat UI on and off
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            inCombat = !inCombat;
//            combatUI.SetActive(inCombat);
//        }
//    }

//    private void FixedUpdate()
//    {
//        // Move the player in the overworld
//        if (!inCombat)
//        {
//            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
//        }
//    }

//    // Enable combat moveset when player enters combat phase
//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.CompareTag("Enemy"))
//        {
//            inCombat = true;
//            combatUI.SetActive(true);
//            GetComponent<CombatMoveset>().enabled = true;
//            GetComponent<OverworldMoveset>().enabled = false;
//        }
//    }

//    // Disable combat moveset when player leaves combat phase
//    private void OnTriggerExit2D(Collider2D other)
//    {
//        if (other.CompareTag("Enemy"))
//        {
//            inCombat = false;
//            combatUI.SetActive(false);
//            GetComponent<CombatMoveset>().enabled = false;
//            GetComponent<OverworldMoveset>().enabled = true;
//        }
//    }
//}
