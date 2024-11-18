using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStarter : MonoBehaviour
{
    [SerializeField] private AudioClip musicClip;

    private void Start()
    {
        SoundManager.Instance.PlayMusic(musicClip);
    }
}
