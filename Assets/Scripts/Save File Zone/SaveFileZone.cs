using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFileZone : MonoBehaviour
{
    [SerializeField] SaveFileScene currentSaveFileScene;
    [SerializeField] string sceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            currentSaveFileScene.sceneForSaveFile = sceneName;
        }
    }
}
