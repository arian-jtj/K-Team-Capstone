using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameButton : MonoBehaviour
{
    [SerializeField] SaveFileScene currentSaveFileScene;

    public void NewGame()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(currentSaveFileScene.sceneForSaveFile);
    }
}
