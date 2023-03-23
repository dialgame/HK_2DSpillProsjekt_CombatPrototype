using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public enum GameState { Overworld, Combat }
public class GameManager : MonoBehaviour
{
    //Player/Enemy-MoveSets talk to Player/Enemy scripts
    //Player/Enemy talks to GameManager
    public GameState currentState;
    [SerializeField] GameObject player;
    private Vector2 originalPlayerPosition;

    public float enemySpawnDistance = 3f; // distance from player to spawn enemy
    public int maxEnemies = 3; // maximum number of enemies to spawn
    [SerializeField] GameObject[] enemyPrefabs;
    private List<GameObject> spawnedEnemies = new List<GameObject>(); // list of spawned enemies


    [SerializeField] Transform combatLocationPlayer;
    [SerializeField] Transform combatLocationEnemy;


    Enemy encounteredEnemy = new Enemy();

    public bool isInCombat = false;


    private void Awake()
    {
        currentState = GameState.Overworld;
    }
    // Start is called before the first frame update
    void Start()
    {
        originalPlayerPosition = player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == GameState.Overworld)
        {

        }
        else if (currentState == GameState.Combat)
        {
            
        }
    }

    public void StartCombat()
    {
        Vector2 playerPosition = player.transform.position;

        currentState = GameState.Combat;

        player.transform.position = combatLocationPlayer.transform.position;

        originalPlayerPosition = playerPosition;
    }

    public void EndCombat()
    {
        currentState = GameState.Overworld;

        player.transform.position = originalPlayerPosition;
    }



}
