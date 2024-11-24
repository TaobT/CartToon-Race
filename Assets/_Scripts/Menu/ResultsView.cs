using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultsView : MonoBehaviour
{
    [SerializeField] private RaceManager raceManager;
    [SerializeField] private GameObject lapResultPrefab;
    [SerializeField] private Transform lapResultsParent;
    [SerializeField] private TextMeshProUGUI totalTimeText;
    [SerializeField] private Image medalImage;
    [SerializeField] private Sprite bronzeMedal;
    [SerializeField] private Sprite silverMedal;
    [SerializeField] private Sprite goldMedal;

    private void OnEnable()
    {
        foreach(Transform child in lapResultsParent)
        {
            Destroy(child.gameObject);
        }

        RaceResults results = raceManager.GetRaceResults();

        for (int i = 0; i < results.lapsTimes.Count; i++)
        {
            GameObject lapResult = Instantiate(lapResultPrefab, lapResultsParent);
            LapResult lapResultComponent = lapResult.GetComponent<LapResult>();
            string lapTime = results.lapsTimes[i].Minutes.ToString("00") + ":" + results.lapsTimes[i].Seconds.ToString("00") + "." + (results.lapsTimes[i].Milliseconds/10).ToString("00");
            lapResultComponent.SetLapResultInfo(i + 1, lapTime);
        }
        string totalTime = results.TotalRaceTime().Minutes.ToString("00") + ":" + results.TotalRaceTime().Seconds.ToString("00") + "." + (results.TotalRaceTime().Milliseconds/10).ToString("00");
        totalTimeText.text = totalTime;

        //If total race time is bigger than 6 minutes, bronze medal
        if (results.TotalRaceTime().TotalSeconds > 360)
        {
            medalImage.sprite = bronzeMedal;
        }
        //If total race time is bigger than 5 minutes, silver medal
        else if (results.TotalRaceTime().TotalSeconds > 300)
        {
            medalImage.sprite = silverMedal;
        }
        //if total race time is lower than 6 minutes, gold medal
        else
        {
            medalImage.sprite = goldMedal;
        }
    }

    public void NextLevel()
    {
        if (!LevelLoader.Instance.LoadNextLevel())
        {
            //No hay mas niveles, volver al menu principal
            LevelLoader.Instance.LoadStartScene();
        }
    }
}
