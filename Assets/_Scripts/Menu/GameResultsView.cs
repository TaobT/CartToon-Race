using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResultsView : MonoBehaviour
{
    [SerializeField] private GameObject raceResultPrefab;
    [SerializeField] private Transform raceResultsParent;
    [SerializeField] private Transform recordsParent;

    [SerializeField] private GameObject mainMenuView;

    private void Start()
    {
        if (GameManager.Instance.AllRacesCompleted)
        {
            gameObject.SetActive(true);
            mainMenuView.SetActive(false);
            MostrarResultados();
        }
        else
        {
            gameObject.SetActive(false);
            mainMenuView.SetActive(true);
        }
    }

    private void MostrarResultados()
    {
        foreach (Transform child in raceResultsParent)
        {
            Destroy(child.gameObject);
        }

        List<RaceResults> results = GameManager.Instance.GetAllRaceResults();

        for (int i = 0; i < results.Count; i++)
        {
            GameObject lapResult = Instantiate(raceResultPrefab, raceResultsParent);
            RaceResult lapResultComponent = lapResult.GetComponent<RaceResult>();
            string totalRaceTime = results[i].TotalRaceTime().Minutes.ToString("00") + ":" + results[i].TotalRaceTime().Seconds.ToString("00") + "." + (results[i].TotalRaceTime().Milliseconds / 10).ToString("00");
            lapResultComponent.SetLapResultInfo("Race " + i, totalRaceTime);
        }
    }

    public void MostrarRecords()
    {
        foreach (Transform child in recordsParent)
        {
            Destroy(child.gameObject);
        }

        List<TimeSpan> records = TimeScoreManager.LoadTimes();

        for (int i = 0; i < records.Count; i++)
        {
            GameObject record = Instantiate(raceResultPrefab, recordsParent);
            RaceResult recordComponent = record.GetComponent<RaceResult>();
            string totalRaceTime = records[i].Minutes.ToString("00") + ":" + records[i].Seconds.ToString("00") + "." + (records[i].Milliseconds / 10).ToString("00");
            recordComponent.SetLapResultInfo("Record " + i, totalRaceTime);
        }
    }

    public void AceptarResultados()
    {
        TimeScoreManager.SaveTime(GameManager.Instance.GetTotalRaceTime());
    }

    public void VolverAlMenu()
    {
        GameManager.Instance.ReiniciarTodo();
        gameObject.SetActive(false);
        mainMenuView.SetActive(true);
    }
}
