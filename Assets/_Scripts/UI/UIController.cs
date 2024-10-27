using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Time Tracker")]
    [SerializeField] private TextMeshProUGUI currentLapTime; // Text for current lap time
    [SerializeField] private GameObject lapTimePf; // Prefab for lap time ("L1: 00:00.00")
    [SerializeField] private Transform lapTimeParent; // Parent object for lap time UI

    [Header("Lap Tracker")]
    [SerializeField] private TextMeshProUGUI currentLap; // Text for current lap
    [SerializeField] private TextMeshProUGUI totalLaps; // Text for total laps

    [Header("Turbo Indicator")]
    [SerializeField] private Slider turboSlider; // Slider for turbo indicator
}
