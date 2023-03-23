//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerOverworld : MonoBehaviour
//{
//    // Reference to the combat move set
//    public MoveSet combatMoveSet;

//    // Reference to the overworld move set
//    public MoveSet overworldMoveSet;

//    // Reference to the game manager
//    private GameManager gameManager;

//    // Boolean flag to check if the player is in combat
//    private bool inCombat = false;

//    // Method to switch between the overworld and combat move sets
//    public void SetOverworldMoveSet()
//    {
//        if (inCombat)
//        {
//            // Switch to the overworld move set
//            GetComponent<MoveController>().SetMoveSet(overworldMoveSet);

//            // Set inCombat to false
//            inCombat = false;

//            // Set the game manager's inCombat flag to false
//            gameManager.inCombat = false;
//        }
//    }

//    // Method to switch to the combat move set
//    public void SetCombatMoveSet()
//    {
//        // Switch to the combat move set
//        GetComponent<MoveController>().SetMoveSet(combatMoveSet);

//        // Set inCombat to true
//        inCombat = true;

//        // Set the game manager's inCombat flag to true
//        gameManager.inCombat = true;
//    }

//    // Start is called before the first frame update
//    void Start()
//    {
//        // Get a reference to the game manager
//        gameManager = FindObjectOfType<GameManager>();

//        // Set the initial move set to the overworld move set
//        GetComponent<MoveController>().SetMoveSet(overworldMoveSet);
//    }

//    // Other methods and code here...
//}
