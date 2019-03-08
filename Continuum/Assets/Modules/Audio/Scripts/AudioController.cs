using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource MusicSource;
    public AudioSource PlayerSFXSource;
    public AudioSource EnemySFXSource;

    private void Awake()
    {
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
}
