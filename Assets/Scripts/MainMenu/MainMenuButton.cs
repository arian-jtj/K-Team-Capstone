using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuButton;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject CreditImage;

    [Header("Options")]
    [SerializeField] private GameObject OptionMenu;
    [SerializeField] private GameObject MusicOnButton;
    [SerializeField] private GameObject MusicOffButton;

    public void PlayButton()
    {
        mainMenuButton.SetActive(false);
        playButton.SetActive(true);
    }

    public void OptionButton()
    {
        OptionMenu.SetActive(true);
    }

    public void CloseOptionButton()
    {
        OptionMenu.SetActive(false);
    }

    public void TurnOnMusic()
    {
        MusicOffButton.SetActive(false);
        MusicOnButton.SetActive(true);
    }
    public void TurnOffMusic()
    {
        MusicOnButton.SetActive(false);
        MusicOffButton.SetActive(true);
    }

    public void CreditButton()
    {
        CreditImage.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void TurnOffCredit()
    {
        CreditImage.SetActive(false);
    }


    public void BackButton()
    {
        playButton.SetActive(false);
        mainMenuButton.SetActive(true);
    }
}
