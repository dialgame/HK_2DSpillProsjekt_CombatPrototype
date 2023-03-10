using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawning : MonoBehaviour
{

    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform respawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("OoB"))
        {
            player.transform.position = respawnPoint.transform.position;
        }
    }
}
