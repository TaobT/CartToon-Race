using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public GameObject sfxSourcePrefab;
    public Transform sfxSourceParent;

    [Header("Volumes")]
    [Range(0, 1)] public float musicVolume = 1f;
    [Range(0, 1)] public float sfxVolume = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        float initialMusicVolume = PlayerPrefs.GetFloat("MusicVolume", musicVolume);
        float initialSFXVolume = PlayerPrefs.GetFloat("SFXVolume", sfxVolume);

        musicVolume = initialMusicVolume;
        sfxVolume = initialSFXVolume;

        // Apply initial volumes
        musicSource.volume = musicVolume;
    }

    /// <summary>
    /// Play background music.
    /// </summary>
    /// <param name="clip">Music clip to play.</param>
    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    /// <summary>
    /// Play a sound effect.
    /// </summary>
    /// <param name="clip">SFX clip to play.</param>
    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;
        GameObject sfxSource = Instantiate(sfxSourcePrefab, sfxSourceParent);
        sfxSource.GetComponent<SoundFX>().Play(clip, sfxVolume);
    }

    /// <summary>
    /// Set the volume of the music.
    /// </summary>
    /// <param name="volume">Volume value between 0 and 1.</param>
    public void SetMusicVolume(float volume)
    {
        // Mathematic formula for volume : 20 * log10(volume)
        musicVolume = 20 * Mathf.Log10(Mathf.Clamp01(volume));
        musicSource.volume = musicVolume;
    }

    /// <summary>
    /// Set the volume of the sound effects.
    /// </summary>
    /// <param name="volume">Volume value between 0 and 1.</param>
    public void SetSFXVolume(float volume)
    {
        sfxVolume = 20 * Mathf.Log10(Mathf.Clamp01(volume));
    }

    /// <summary>
    /// Pause the music.
    /// </summary>
    public void PauseMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Pause();
        }
    }

    /// <summary>
    /// Resume the paused music.
    /// </summary>
    public void ResumeMusic()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }
}
