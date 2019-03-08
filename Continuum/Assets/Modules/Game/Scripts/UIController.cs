using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button PauseButton;
    public Button UnpauseButton;
    public Button HomeButton;
    public Slider MusicVolume;
    public Slider SFXVolume;
    public RectTransform ConfigScreen;

    public Text Score;

    private void Awake()
    {
        PauseButton.onClick.AddListener(Pause);
        UnpauseButton.onClick.AddListener(Unpause);
        HomeButton.onClick.AddListener(GoToHome);
    }

    public void Pause()
    {
        MusicVolume.normalizedValue = PlayerPrefsController.Instance.GetMusicVolume();
        SFXVolume.normalizedValue = PlayerPrefsController.Instance.GetSFXVolume();

        ConfigScreen.DOScale(1f, 0.25f).SetUpdate(true);
        Time.timeScale = 0.001f;
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
        ConfigScreen.DOScale(0f, 0.25f).SetUpdate(true);

        PlayerPrefsController.Instance.SetMusicVolume(MusicVolume.normalizedValue);
        PlayerPrefsController.Instance.SetSFXVolume(SFXVolume.normalizedValue);
    }

    public void GoToHome()
    {
        SceneManager.LoadScene(0);
    }
}
