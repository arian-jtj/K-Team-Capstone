using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPromptZone : MonoBehaviour
{
    [SerializeField] private GameObject interactPromptUI;

    [SerializeField] private DoorActiveStatus doorStatus;
    private Collider2D _collider;

    private void Start()
    {
        _collider = gameObject.GetComponent<Collider2D>();
    }

    private void Update()
    {
        if(doorStatus.isDoorCurrentlyActive == true)
        {
            _collider.enabled = true;
        }
        else
        {
            _collider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            interactPromptUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            interactPromptUI.SetActive(false);
        }
    }
}