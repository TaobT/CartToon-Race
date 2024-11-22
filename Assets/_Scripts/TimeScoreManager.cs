using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimeScoreManager
{
    private static int MaxScores = 5;

    public static void SaveTime(float seconds)
    {
        TimeSpan time = TimeSpan.FromSeconds(seconds);
        // Cargar los tiempos actuales desde PlayerPrefs
        List<TimeSpan> times = LoadTimes();

        // Añadir el nuevo tiempo
        times.Add(time);

        // Ordenar los tiempos de menor a mayor
        times.Sort();

        // Mantener solo los mejores 5
        if (times.Count > MaxScores)
        {
            times = times.GetRange(0, MaxScores);
        }

        // Guardar los tiempos actualizados en PlayerPrefs
        for (int i = 0; i < times.Count; i++)
        {
            PlayerPrefs.SetFloat($"Time_{i}", (float) times[i].TotalSeconds);
        }

        // Borrar los tiempos antiguos sobrantes
        for (int i = times.Count; i < MaxScores; i++)
        {
            PlayerPrefs.DeleteKey($"Time_{i}");
        }

        PlayerPrefs.Save();
    }

    public static List<TimeSpan> LoadTimes()
    {
        List<float> floatTimes = new List<float>();

        for (int i = 0; i < MaxScores; i++)
        {
            if (PlayerPrefs.HasKey($"Time_{i}"))
            {
                floatTimes.Add(PlayerPrefs.GetFloat($"Time_{i}"));
            }
        }

        List<TimeSpan> times = new List<TimeSpan>();

        foreach (float time in floatTimes)
        {
            times.Add(TimeSpan.FromSeconds(time));
        }
        return times;
    }

    public static List<TimeSpan> LoadTestTimes()
    {
        List<TimeSpan> floatTimes = new List<TimeSpan>();

        floatTimes.Add(TimeSpan.FromSeconds(100));
        floatTimes.Add(TimeSpan.FromSeconds(200));
        floatTimes.Add(TimeSpan.FromSeconds(300));

        return floatTimes;
    }

    public static string FormatTime(float timeInSeconds)
    {
        // Formato MM:SS.ss
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeInSeconds);
        return string.Format("{0:D2}:{1:D2}.{2:D2}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
    }
}
