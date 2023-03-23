//using UnityEngine;



//public class EnemySpawner : MonoBehaviour
//{
//    public GameObject[] slimePrefabs;
//    public GameObject[] lionPrefabs;
//    [SerializeField] Collider2D enemyCollider;

//    // Combat arena location
//    public Transform combatArena;

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.CompareTag("Player"))
//        {
//            // Disable the player's overworld move set
//           // collision.GetComponent<PlayerController>().overworldMoveSet.enabled = false;

//            // Find the enemy controller and enable its combat move set
//            EnemyOverworldActions enemyController = GetComponent<EnemyOverworldActions>();
//            //enemyController.SetMoveSet(enemyController.combatMoveSet);

//            // Get the enemy type and spawn the appropriate enemy prefab(s)
//            EnemyType enemyType = enemyController.enemyType;
//            GameObject[] enemyPrefabs = null;

//            switch (enemyType)
//            {
//                case EnemyType.Slime:
//                    enemyPrefabs = slimePrefabs;
//                    break;
//                case EnemyType.Lion:
//                    enemyPrefabs = lionPrefabs;
//                    break;
//                default:
//                    // Handle unknown enemy types here
//                    break;
//            }

//            if (enemyPrefabs != null)
//            {
//                int enemyCount = Random.Range(1, 4);

//                // Spawn the enemy prefab(s) near the combat arena
//                for (int i = 0; i < enemyCount; i++)
//                {
//                    Vector3 enemyPosition = combatArena.position + new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
//                    Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], enemyPosition, Quaternion.identity);
//                }
//            }
//        }
//    }
//}
