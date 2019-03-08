using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    public AudioSource MusicSource;
    public AudioSource PlayerSFXSource;
    public AudioSource EnemySFXSource;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        PlayerPrefsController.Instance.OnMusicVolumeChanged.AddListener(
            () =>
            {
                MusicSource.volume = PlayerPrefsController.Instance.GetMusicVolume();
            });
        PlayerPrefsController.Instance.OnSFXVolumeChanged.AddListener(
            () =>
            {
                PlayerSFXSource.volume = PlayerPrefsController.Instance.GetSFXVolume();
                EnemySFXSource.volume = PlayerPrefsController.Instance.GetSFXVolume();
            });
    }

    public void PlayOneShotPlayerSFX(AudioClip clip)
    {
        PlayerSFXSource.PlayOneShot(clip);
    }

    public void PlayOneShotEnemySFX(AudioClip clip)
    {
        EnemySFXSource.PlayOneShot(clip);
    }
}
