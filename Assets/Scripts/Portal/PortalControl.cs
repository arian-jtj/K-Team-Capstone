using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControl : MonoBehaviour
{
    private PortalToggle portalToggle;
    public Player player;

    void Start()
    {
        portalToggle = GameObject.FindObjectOfType<PortalToggle>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Player is outside the portal when the player's collider exits the portal's collider
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Close the portal when the player exits
            portalToggle.ClosePortal();
        }
    }
}
