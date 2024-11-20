using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalToggle : MonoBehaviour
{
    public GameObject portal;
    public GameObject player;
    private bool portalIsActive;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            portal.transform.position = player.transform.position;
            portalIsActive = !portalIsActive;
            portal.SetActive(portalIsActive);
        }
    }
}
