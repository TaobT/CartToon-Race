using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResultsView : MonoBehaviour
{
    [SerializeField] private GameObject raceResultPrefab;
    [SerializeField] private Transform raceResultsParent;

    private void Start()
    {
        if (GameManager.Instance.AllRacesCompleted)
        {
            gameObject.SetActive(true);
            MostrarResultados();
        }
        else gameObject.SetActive(false);
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
            lapResultComponent.SetLapResultInfo("Race " + i, results[i].TotalRaceTime().ToString());
        }
    }

    public void Aceptar()
    {
        GameManager.Instance.ReiniciarTodo();
        gameObject.SetActive(false);
    }
}
