using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LapResult : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lapNumberText;
    [SerializeField] private TextMeshProUGUI lapTimeText;

    public void SetLapResultInfo(int lapNumber, string lapTime)
    {
        lapNumberText.text = "L" + lapNumber.ToString();
        lapTimeText.text = lapTime;
    }
}
