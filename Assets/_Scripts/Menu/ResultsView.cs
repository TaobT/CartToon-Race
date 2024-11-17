using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultsView : MonoBehaviour
{
    [SerializeField] private RaceManager raceManager;
    [SerializeField] private GameObject lapResultPrefab;
    [SerializeField] private Transform lapResultsParent;
    [SerializeField] private TextMeshProUGUI totalTimeText;

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
            lapResultComponent.SetLapResultInfo(i + 1, results.lapsTimes[i].ToString());
        }
    }

    public void NextLevel()
    {
        if (!LevelLoader.Instance.LoadNextLevel())
        {
            //No hay mas niveles, volver al menu principal
            LevelLoader.Instance.LoadLevel();
        }
    }
}
