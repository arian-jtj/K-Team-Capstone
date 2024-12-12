using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorToMinigame : MonoBehaviour
{
    private bool isInFrontOfDoor;

    [SerializeField] private GameObject SceneManager;
    private SceneController sceneControllerScript;

    [SerializeField] private DoorActiveStatus doorStatus;
    private SpriteRenderer _sprite;
    private Collider2D _collider;

    void Start()
    {
        sceneControllerScript = SceneManager.GetComponent<SceneController>();

        _sprite = gameObject.GetComponent<SpriteRenderer>();
        _collider = gameObject.GetComponent<Collider2D>();
    }

    void Update()
    {
        if(doorStatus.isDoorCurrentlyActive == true)
        {
            _sprite.enabled = true;
            _collider.enabled = true;
        }
        else
        {
            _sprite.enabled = false;
            _collider.enabled = false;
        }

        if(Input.GetKeyDown(KeyCode.F) && isInFrontOfDoor)
        {
            doorStatus.isDoorCurrentlyActive = false;
            DontDestroyOnLoad(this.gameObject);
            sceneControllerScript.ChangeScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isInFrontOfDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isInFrontOfDoor = false;
        }
    }
}
