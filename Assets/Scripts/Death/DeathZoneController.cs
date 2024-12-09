using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneController : MonoBehaviour
{
    public GameObject player;
    private Player playerScript;

    private void Start()
    {
        playerScript = player.GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player.transform.position = playerScript.spawnPosition.changingValue;
        }
    }
}
