using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceResults
{
    public List<TimeSpan> lapsTimes = new List<TimeSpan>();

    public TimeSpan TotalRaceTime()
    {
        TimeSpan totalRaceTime = new TimeSpan();
        foreach (TimeSpan lapTime in lapsTimes)
        {
            totalRaceTime += lapTime;
        }
        return totalRaceTime;
    }
}
