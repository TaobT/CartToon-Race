using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private RaceManager raceManager;
    [SerializeField] private CarMovement carMovement;

    [Header("Time Tracker")]
    [SerializeField] private TextMeshProUGUI currentLapTime; // Text for current lap time
    [SerializeField] private GameObject lapTimePf; // Prefab for lap time ("L1: 00:00.00")
    [SerializeField] private Transform lapTimeParent; // Parent object for lap time UI

    [Header("Lap Tracker")]
    [SerializeField] private TextMeshProUGUI currentLap; // Text for current lap
    [SerializeField] private TextMeshProUGUI totalLaps; // Text for total laps

    [Header("Turbo Indicator")]
    [SerializeField] private Slider turboSlider; // Slider for turbo indicator

    private void OnEnable()
    {
        RaceController.OnLapFinished += OnLapFinishedInstant;
    }

    private void OnDisable()
    {
        RaceController.OnLapFinished -= OnLapFinishedInstant;
    }

    private void Start()
    {
        totalLaps.text = "/" + raceManager.Laps.ToString();
    }

    private void Update()
    {
        CurrentLapTime();
    }

    private void OnLapFinishedInstant()
    {
        StartCoroutine(OnLapFinished1Frame());
    }

    private IEnumerator OnLapFinished1Frame()
    {
        yield return null;
        UpdateCurrentLaps();
    }

    private void UpdateCurrentLaps()
    {
        currentLap.text = (raceManager.CurrentLaps).ToString();
    }

    private void CurrentLapTime()
    {
        if (raceManager.CurrentPhase != RaceManager.RacePhase.Racing) return;
        float currentLapTime = raceManager.GetCurrentLapTime();
        this.currentLapTime.text = currentLapTime.ToString("00:00.00");
    }

    public void TurboSliderValue()
    {
        turboSlider.value = carMovement.GetBoostFactor();
    }
}
