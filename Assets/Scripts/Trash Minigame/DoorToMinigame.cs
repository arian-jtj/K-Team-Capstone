using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToMinigame : MonoBehaviour
{
    //Check if its cleared
    private bool isCleared = false;

    private bool isInFrontOfDoor;

    [SerializeField] private GameObject SceneManager;
    private SceneController sceneControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        sceneControllerScript = SceneManager.GetComponent<SceneController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCleared)
        {
            gameObject.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.F) && isInFrontOfDoor)
        {
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
