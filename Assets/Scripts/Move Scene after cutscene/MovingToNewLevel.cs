using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingToNewLevel : MonoBehaviour
{
    [SerializeField] private GameObject sceneManager;
    private LevelSceneTransition sceneController;
    // Start is called before the first frame update
    void Start()
    {
        sceneController = sceneManager.GetComponent<LevelSceneTransition>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            sceneController.ChangeLevel();
        }
    }
}
