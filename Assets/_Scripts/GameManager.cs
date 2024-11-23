using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private bool race1Completed = false;
    private RaceResults race1Results = new RaceResults();
    private bool race2Completed = false;
    private RaceResults race2Results = new RaceResults();
    private bool race3Completed = false;
    private RaceResults race3Results = new RaceResults();

    public bool Race1Completed => race1Completed;
    public RaceResults Race1Results => race1Results;
    public bool Race2Completed => race2Completed;
    public RaceResults Race2Results => race2Results;
    public bool Race3Completed => race3Completed;
    public RaceResults Race3Results => race3Results;

    public bool AllRacesCompleted => race1Completed && race2Completed;

    public void ReiniciarTodo()
    {
        race1Completed = false;
        race2Completed = false;
        race3Completed = false;

        race3Results = new RaceResults();
        race1Results = new RaceResults();
        race2Results = new RaceResults();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool IsRace1Completed()
    {
        return race1Completed;
    }

    public bool IsRace2Completed()
    {
        return race2Completed;
    }

    public bool IsRace3Completed()
    {
        return race3Completed;
    }

    public void RegisterRace1Results(RaceResults results)
    {
        race1Results = results;
        race1Completed = true;
    }

    public void RegisterRace2Results(RaceResults results)
    {
        race2Results = results;
        race2Completed = true;
    }

    public void RegisterRace3Results(RaceResults results)
    {
        race3Results = results;
        race3Completed = true;
    }

    public List<RaceResults> GetAllRaceResults()
    {
        return new List<RaceResults> { race1Results, race2Results };
    }

    public float GetTotalRaceTime()
    {
        return race1Results.TotalRaceTime().Seconds + race2Results.TotalRaceTime().Seconds;
    }
}
