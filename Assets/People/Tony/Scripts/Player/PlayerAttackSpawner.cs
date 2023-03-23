using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSpawner : MonoBehaviour
{
    //player scripts
    [SerializeField] Transform playerPosition;
    
    [SerializeField] MeleeOverworldHit playerOverworldMoveSet;
    [SerializeField] T_MeleeHit playerCombatMoveSet;
    [SerializeField] T_PlayerMovement playerOverworldMovement;
    public EnemyType enemyType;




    //enemy scripts
    [SerializeField] T_EnemyStats enemyCombatMoveset;
    [SerializeField] EnemyOverworldActions enemyOverworldMoveset;
    [SerializeField] T_SlimeMovement enemyOverworldMovement;

    //public EnemyType enemyType;
    //spawn enemy
    public GameObject[] slimePrefabs;
    public GameObject[] lionPrefabs;

    // Minimum distance between spawned enemies and player
    public float minDistanceToPlayer = 5f;
    // Minimum distance between spawned enemies
    public float minDistanceBetweenEnemies = 2f;

    // Combat arena location
    public Transform combatArena;

    [SerializeField] GameObject shatterScreenManager;

    private void Update()
    {
    }
    public void SpawnEnemies()
    {

        StartCoroutine(SpawnEnemiesCoroutine());
        Debug.Log("attack spawnn");

    }
    private IEnumerator SpawnEnemiesCoroutine()
    {
        MeleeOverworldHit playerController = GetComponent<MeleeOverworldHit>();

        enemyType = playerController.enemyType;
        GameObject[] enemyPrefabs = null;

        switch (enemyType)
        {
            case EnemyType.Slime:
                enemyPrefabs = slimePrefabs;
                break;
            case EnemyType.Lion:
                enemyPrefabs = lionPrefabs;
                break;
            default:
                // Handle unknown enemy types here
                break;
        }

        if (enemyPrefabs != null)
        {
            //playerOverworldMovement.enabled = false;
            //enemyOverworldMovement.enabled = false;
            int enemyCount = Random.Range(1, 4);



            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 enemyPosition = combatArena.position + Vector3.zero;

                bool tooCloseToPlayer = true;
                bool tooCloseToOtherEnemy = true;

                // Keep trying to find a valid position until one is found
                while (tooCloseToPlayer || tooCloseToOtherEnemy)
                {
                    enemyPosition = combatArena.position + new Vector3(Random.Range(-7f, 7f), Random.Range(-7f, 7f), 0f);
                    float distanceToPlayer = Vector3.Distance(enemyPosition, combatArena.position);
                    tooCloseToPlayer = distanceToPlayer < minDistanceToPlayer;

                    if (i > 0)
                    {
                        float distanceToOtherEnemy = Vector3.Distance(enemyPosition, transform.position + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f));
                        tooCloseToOtherEnemy = distanceToOtherEnemy < minDistanceBetweenEnemies;
                    }
                    else
                    {
                        tooCloseToOtherEnemy = false;
                    }
                }

                Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], enemyPosition, Quaternion.identity);

            }


            yield return new WaitForSeconds(2f);
            enemyCombatMoveset.enabled = true;
            enemyOverworldMoveset.enabled = false;
            enemyOverworldMovement.enabled = true;

            playerCombatMoveSet.enabled = true;
            playerOverworldMoveSet.enabled = false;
            playerOverworldMovement.enabled = true;

            shatterScreenManager.SetActive(false);



        }
    }
}
