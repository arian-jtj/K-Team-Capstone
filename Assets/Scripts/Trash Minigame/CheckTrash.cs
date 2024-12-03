using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrash : MonoBehaviour
{
    [SerializeField] private float totalTrashAmount;
    private float trashRemovedCounter = 0;

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
        if(trashRemovedCounter == totalTrashAmount)
        {
            sceneControllerScript.ChangeScene();
        }
    }

    public void addCounter()
    {
        trashRemovedCounter++;
    }
}