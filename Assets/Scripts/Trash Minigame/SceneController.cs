using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] Animator transitionAnimation;
    public string transitionSceneTo;

    public Vector2 playerSpawnPosition;
    public PlayerVectorValue playerStorage;

    public void ChangeScene()
    {
        playerStorage.changingValue = playerSpawnPosition;
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        transitionAnimation.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(transitionSceneTo);
        transitionAnimation.SetTrigger("Start");
    }
}
