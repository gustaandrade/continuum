using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPrefsController : MonoBehaviour
{
    public static PlayerPrefsController Instance;

    public UnityEvent OnMusicVolumeChanged;
    public UnityEvent OnSFXVolumeChanged;
    public UnityEvent OnScoreValueChanged;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public float GetMusicVolume()
    {
        if (!PlayerPrefs.HasKey("Music")) return 1;
        return PlayerPrefs.GetFloat("Music");
    }

    public void SetMusicVolume(float value)
    {
        PlayerPrefs.SetFloat("Music", value);
        OnMusicVolumeChanged.Invoke();
    }

    public float GetSFXVolume()
    {
        if (!PlayerPrefs.HasKey("SFX")) return 1;
        return PlayerPrefs.GetFloat("SFX");
    }

    public void SetSFXVolume(float value)
    {
        PlayerPrefs.SetFloat("SFX", value);
        OnSFXVolumeChanged.Invoke();
    }

    public float GetMaxScore()
    {
        if (!PlayerPrefs.HasKey("Score")) return 0;
        return PlayerPrefs.GetFloat("Score");
    }

    public void SetMaxScore(float value)
    {
        PlayerPrefs.SetFloat("Score", value);
        OnScoreValueChanged.Invoke();
    }
}
