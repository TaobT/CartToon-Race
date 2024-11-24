using Doozy.Runtime.UIManager.Components;
using Doozy.Runtime.UIManager.Containers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private UISlider musicVolumeSlider;
    [SerializeField] private UISlider sfxVolumeSlider;
    private UIView view;

    private float lastMusicVolume;
    private float lastSFXVolume;

    private void Awake()
    {
        view = GetComponent<UIView>();
        view.OnShowCallback.Event.AddListener(() =>
        {
            lastMusicVolume = SoundManager.Instance.musicVolume;
            lastSFXVolume = SoundManager.Instance.sfxVolume;
        });
    }

    private void Start()
    {
        musicVolumeSlider.OnValueChanged.AddListener((float value) => SoundManager.Instance.SetMusicVolume(value));
        sfxVolumeSlider.OnValueChanged.AddListener((float value) => SoundManager.Instance.SetSFXVolume(value));
    }

    private void OnEnable()
    {
        try
        {
            musicVolumeSlider.value = SoundManager.Instance.musicVolume;
            sfxVolumeSlider.value = SoundManager.Instance.sfxVolume;
        }
        catch
        {
            musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);
            sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1);
        }
    }

    public void AcceptSettings()
    {
        SoundManager.Instance.SetMusicVolume(musicVolumeSlider.value);
        SoundManager.Instance.SetSFXVolume(sfxVolumeSlider.value);

        PlayerPrefs.SetFloat("MusicVolume", SoundManager.Instance.musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", SoundManager.Instance.sfxVolume);
    }

    public void CancelSettings()
    {
        SoundManager.Instance.SetMusicVolume(lastMusicVolume);
        SoundManager.Instance.SetSFXVolume(lastSFXVolume);
    }
}
