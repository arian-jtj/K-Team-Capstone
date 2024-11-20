using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControl : MonoBehaviour
{
    private PlayerController player;

    Collider2D platformCollider;
    public bool platformInPortal; //check if the platform is intended for inside or outside of the portal

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        platformCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        // If the platform is meant for inside of the portal, the platform's collider will be enabled if the player is inside of the portal
        // and the platform's collider will be disabled if the player is outside of the portal
        if(platformInPortal == true)
        {
            if(player.isInPortal == true)
            {
                platformCollider.enabled = true;
            }
            else if(player.isInPortal == false)
            {
                platformCollider.enabled = false;
            }
        }

        // If the platform is meant for outside of the portal, the platform's collider will be disabled if the player is inside of the portal
        // and the platform's collider will be enabled if the player is outside of the portal
        else if(platformInPortal == false)
        {
            if(player.isInPortal == true)
            {
                platformCollider.enabled = false;
            }
            else if(player.isInPortal == false)
            {
                platformCollider.enabled = true;
            }
        }
    }
}
