using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RaceManager : MonoBehaviour
{
    public enum RacePhase
    {
        None,
        Starting,
        Racing,
        Finished
    }

    public enum RaceLevel
    {
        First,
        Second,
        Third
    }

    private RacePhase currentPhase = RacePhase.None;
    public RacePhase CurrentPhase => currentPhase;

    [SerializeField] private RaceLevel raceLevel;
    [SerializeField] private GameObject resultsView;
    [SerializeField] private Transform carModel;
    [SerializeField] private CarMovement carMovement;
    [SerializeField] private Animator countDown;

    private int laps = 3;
    public int Laps => laps;
    private int currentLaps = 0;
    public int CurrentLaps => currentLaps;
    private RaceResults raceResults = new RaceResults();
    private float lapStartTime;

    private void OnEnable()
    {
        CountDown.OnCountDownFinished += StartingCountDownFinished;
        RaceController.OnLapFinished += OnLapEnded;
    }

    private void OnDisable()
    {
        CountDown.OnCountDownFinished -= StartingCountDownFinished;
        RaceController. OnLapFinished -= OnLapEnded;
    }

    private void OnDestroy()
    {
        CountDown.OnCountDownFinished -= StartingCountDownFinished;
        RaceController.OnLapFinished -= OnLapEnded;
    }

    private void Awake()
    {
        Starting();
    }


    private void Starting() 
    {
        //Obtener el numero de vueltas
        //Cargar el modelo del auto
        GameObject carModel = RaceConfigurations.Instance.GetCarModel();
        if (carModel != null)
        {
            Transform modelTransform = Instantiate(carModel, this.carModel).transform;
        }
        else
        {
            Debug.LogError("Car model not found");
        }

        currentPhase = RacePhase.Starting;
        carMovement.SetCanMove(false);
        countDown.transform.gameObject.SetActive(true);
    }

    private void StartingCountDownFinished()
    {
        Racing();
    }

    private void Racing()
    {
        currentPhase = RacePhase.Racing;
        lapStartTime = Time.time;
        carMovement.SetCanMove(true);
    }

    private void OnLapEnded()
    {
        currentLaps += 1;
        if (currentLaps >= laps)
        {
            FinishRace();
        }
        else
        {
            Debug.Log("Laps : " + currentLaps + "/" + laps);
            raceResults.lapsTimes.Add(TimeSpan.FromSeconds(Time.time - lapStartTime));
            lapStartTime = Time.time;
        }
    }

    private void FinishRace()
    {
        currentPhase = RacePhase.Finished;
        raceResults.lapsTimes.Add(TimeSpan.FromSeconds(Time.time - lapStartTime));

        //Show results screen
        resultsView.SetActive(true);
        carMovement.SetCanMove(false);

        switch (raceLevel)
        {
            case RaceLevel.First:
                GameManager.Instance.RegisterRace1Results(raceResults);
                break;
            case RaceLevel.Second:
                GameManager.Instance.RegisterRace2Results(raceResults);
                break;
            case RaceLevel.Third:
                GameManager.Instance.RegisterRace3Results(raceResults);
                break;
        }
    }

    public float GetCurrentLapTime()
    {
        return Time.time - lapStartTime;
    }

    public RaceResults GetRaceResults()
    {
        return raceResults;
    }
}
