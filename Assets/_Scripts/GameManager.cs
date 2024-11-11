using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool race1Completed = false;
    private bool race2Completed = false;
    private bool race3Completed = false;

    public void MarkRace1Completed()
    {
        race1Completed = true;
    }

    public void MarkRace2Completed()
    {
        race2Completed = true;
    }

    public void MarkRace3Completed()
    {
        race3Completed = true;
    }

    public bool IsGameCompleted()
    {
        return race1Completed && race2Completed && race3Completed;
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
}
