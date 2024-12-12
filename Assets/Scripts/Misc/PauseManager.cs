using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject musicOnButton;
    [SerializeField] private GameObject musicOffButton;

    public void OpenPauseMenu()
    {
        Debug.Log("Bisa");
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void TurnOnMusicButton()
    {
        musicOffButton.SetActive(false);
        musicOnButton.SetActive(true);
        Debug.Log("TURNON");
    }

    public void TurnOffMusicButton()
    {
        musicOnButton.SetActive(false);
        musicOffButton.SetActive(true);
        Debug.Log("TURNOFF");
    }

    public void GoToMainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
