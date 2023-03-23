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

       // player.GetComponent<Player>().SetOverworldMoveSet();
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

        //player.SetCombatMoveSet();

        ////Spawn enemy
        //int enemyAmount = Random.Range(1, maxEnemies + 1);
        //for (int i = 0; i < enemyAmount; i++)
        //{
        //    //GameObject newEnemy = Instantiate(enemyPrefabs.First(e => e.GetComponent<Enemy>().enemyType == enemyType), combatLocationEnemy.transform.position, Quaternion.identity);
        //    GameObject newEnemy = Instantiate(enemyPrefabs.First(e => e.GetComponent<Enemy>().enemyType == encounteredEnemy.enemyType), combatLocationEnemy.transform.position, Quaternion.identity);

        //    newEnemy.GetComponent<Enemy>().SetCombatMoveSet();

        //}
        originalPlayerPosition = playerPosition;
    }

    public void EndCombat()
    {
        currentState = GameState.Overworld;

        player.transform.position = originalPlayerPosition;
        //player.GetComponent<Player>().SetOverworldMoveSet();
    }



    //void SpawnEnemies(Vector3 playerPosition)
    //{
    //    // spawn up to maxEnemies enemies within enemySpawnDistance of the player
    //    for (int i = 0; i < maxEnemies; i++)
    //    {
    //        Vector3 spawnPosition = GetRandomSpawnPosition(playerPosition);
    //        GameObject enemyPrefab = GetRandomEnemyPrefab();
    //        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    //        spawnedEnemies.Add(enemy);
    //    }
    //}

    //Vector3 GetRandomSpawnPosition(Vector3 playerPosition)
    //{
    //    // keep trying to find an unoccupied position until we succeed
    //    while (true)
    //    {
    //        // generate a random position within enemySpawnDistance of the player
    //        Vector3 randomOffset = Random.insideUnitCircle.normalized * enemySpawnDistance;
    //        Vector3 spawnPosition = playerPosition + randomOffset;

    //        // check if there is already an enemy at this position
    //        bool positionOccupied = false;
    //        foreach (GameObject enemy in spawnedEnemies)
    //        {
    //            if (Vector3.Distance(enemy.transform.position, spawnPosition) < 1f)
    //            {
    //                positionOccupied = true;
    //                break;
    //            }
    //        }

    //        // if the position is unoccupied, return it
    //        if (!positionOccupied)
    //        {
    //            return spawnPosition;
    //        }
    //    }
    //}

}
