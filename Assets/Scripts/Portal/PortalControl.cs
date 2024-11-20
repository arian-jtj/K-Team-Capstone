using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalMask : MonoBehaviour
{
    public Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Player is inside the portal when the player's collider enters the portal's collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player.isInPortal = true;
        }
    }

    // Player is outside the portal when the player's collider exits the portal's collider
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player.isInPortal = false;
        }
    }
}
