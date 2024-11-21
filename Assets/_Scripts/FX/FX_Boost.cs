using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX_Boost : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    [SerializeField] private BoostLevel _boostLevel;
    [SerializeField] private BoostLevelConfig lowBoost;
    [SerializeField] private BoostLevelConfig mediumBoost;
    [SerializeField] private BoostLevelConfig highBoost;

    private BoostLevel currentBoostLevel;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystem.Stop();
    }

    public void SwitchBoostLevel(BoostLevel boostLevel)
    {
        if(currentBoostLevel == boostLevel)
        {
            return;
        }

        currentBoostLevel = boostLevel;

        switch(boostLevel)
        {
            case BoostLevel.None:
                _particleSystem.Stop();
                break;
            case BoostLevel.Low:
                SetBoostConfig(lowBoost);
                _particleSystem.Play();
                break;
            case BoostLevel.Medium:
                SetBoostConfig(mediumBoost);
                _particleSystem.Play();
                break;
            case BoostLevel.High:
                SetBoostConfig(highBoost);
                _particleSystem.Play();
                break;
        }
    }

    private void SetBoostConfig(BoostLevelConfig config)
    {

        var main = _particleSystem.main;
        main.startLifetime = config.startLifeTime;
        var colorOverLifeTime = _particleSystem.colorOverLifetime;
        colorOverLifeTime.color = config.colorOverLifeTime;
    }
}

[System.Serializable]
public struct BoostLevelConfig
{
    public float startLifeTime;
    public Gradient colorOverLifeTime;
}