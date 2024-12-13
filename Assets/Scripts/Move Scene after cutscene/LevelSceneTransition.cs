using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class LevelSceneTransition : MonoBehaviour
{
    [SerializeField] Animator transitionAnimation;
    public string transitionSceneTo;

    // Start is called before the first frame update
    void Start()
    {
        
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
