using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    private Vector2 playerSpawnPosition;
    public PlayerVectorValue playerStorage;

    private void Start()
    {
        playerSpawnPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerStorage.changingValue = playerSpawnPosition;
        }
    }
}
