using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPromptZone : MonoBehaviour
{
    [SerializeField] private GameObject portalPromptUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            portalPromptUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            portalPromptUI.SetActive(false);
        }
    }
}
