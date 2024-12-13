using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoLevelTransition : MonoBehaviour
{
    [SerializeField] Animator transitionAnimation;
    public string transitionSceneTo;
    private VideoPlayer videoPlayer;
    private bool isPause = false;

    private void Start()
    {
        if (videoPlayer == null)
            videoPlayer = GetComponent<VideoPlayer>();


        if (videoPlayer != null)
            videoPlayer.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        transitionAnimation.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(transitionSceneTo);
        transitionAnimation.SetTrigger("Start");
    }
    // Start is called before the first frame update
    public void TogglePause()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            isPause = true;
        }
        else
        {
            videoPlayer.Play();
            isPause = false;
        }
    }
}
