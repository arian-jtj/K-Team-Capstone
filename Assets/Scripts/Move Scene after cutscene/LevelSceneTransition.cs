using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class LevelSceneTransition : MonoBehaviour
{
    [SerializeField] Animator transitionAnimation;
    public string transitionSceneTo;

    public Vector2 playerSpawnPosition;
    public PlayerVectorValue playerStorage;

    // Start is called before the first frame update
    public void ChangeLevel()
    {
        playerStorage.changingValue = playerSpawnPosition;
        StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    IEnumerator LoadScene()
    {
        transitionAnimation.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(transitionSceneTo);
        transitionAnimation.SetTrigger("Start");
    }
}
