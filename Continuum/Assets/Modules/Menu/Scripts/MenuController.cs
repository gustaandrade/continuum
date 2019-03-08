using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button StartButton;
    public Button ConfigButton;
    public Button CreditsButton;
    public Button CloseButton;

    public RectTransform StartPanel;
    public RectTransform ConfigPanel;
    public RectTransform CreditsPanel;
    public RectTransform ClosePanel;

    public Slider MusicVolume;
    public Slider SFXVolume;

    public AudioClip ClickClip;

    private void Awake()
    {
        StartButton.onClick.AddListener(() => OpenMenu("Start"));
        ConfigButton.onClick.AddListener(() => OpenMenu("Config"));
        CreditsButton.onClick.AddListener(() => OpenMenu("Credits"));
        CloseButton.onClick.AddListener(() => OpenMenu("Close"));
    }

    private void OpenMenu(string screenName)
    {
        AudioController.Instance.PlayOneShotPlayerSFX(ClickClip);

        switch (screenName)
        {
            case "Start":
                StartPanel.DOScale(1f, 0.25f);
                break;
            case "Config":
                MusicVolume.normalizedValue = PlayerPrefsController.Instance.GetMusicVolume();
                SFXVolume.normalizedValue = PlayerPrefsController.Instance.GetSFXVolume();
                ConfigPanel.DOScale(1f, 0.25f);
                break;
            case "Credits":
                CreditsPanel.DOScale(1f, 0.25f);
                break;
            case "Close":
                ClosePanel.DOScale(1f, 0.25f);
                break;
        }
    }

    public void CloseCurrentPanel(RectTransform rectTransform)
    {
        AudioController.Instance.PlayOneShotPlayerSFX(ClickClip);

        rectTransform.DOScale(0f, 0.25f);
    }

    public void QuitApplication()
    {
        AudioController.Instance.PlayOneShotPlayerSFX(ClickClip);

        Application.Quit();
    }

    public void SaveSoundPrefs()
    {
        PlayerPrefsController.Instance.SetMusicVolume(MusicVolume.normalizedValue);
        PlayerPrefsController.Instance.SetSFXVolume(SFXVolume.normalizedValue);
    }

    public void LoadLevel(int level)
    {
        AudioController.Instance.PlayOneShotPlayerSFX(ClickClip);

        SceneManager.LoadScene(level);
    }
}
