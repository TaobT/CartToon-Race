using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaceResult : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI raceNameText;
    [SerializeField] private TextMeshProUGUI lapTimeText;

    public void SetLapResultInfo(string raceName, string raceTime)
    {
        raceNameText.text = raceName;
        lapTimeText.text = raceTime;
    }
}
