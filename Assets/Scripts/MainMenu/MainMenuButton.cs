using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuButton;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject CreditImage;

    public void PlayButton()
    {
        mainMenuButton.SetActive(false);
        playButton.SetActive(true);
    }

    public void OptionButton()
    {

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
