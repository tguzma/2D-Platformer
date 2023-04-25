using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public static class ScoreHandler
{
    static DateTime TimeStarted;
    static TimeSpan TotalTime;
    static int Deaths;
    static int CollectedObjects;

    public static TimeSpan TimeLeft
    {
        get
        {
            var result = TotalTime - (DateTime.UtcNow - TimeStarted);
            if (result.TotalSeconds <= 0)
                return TimeSpan.Zero;
            return result;
        }
    }

    public static void Start(TimeSpan totalTime)
    {
        Deaths = 0;
        CollectedObjects = 0;
        TimeStarted = DateTime.UtcNow;
        TotalTime = totalTime;
    }
    
    public static void Died()
    {
        Deaths++;
    }

    public static TimeSpan GetTime() => (TotalTime - TimeLeft);
    public static string GetDeaths() => Deaths.ToString();
    public static string GetCollected() => CollectedObjects.ToString();

    public static int CalculateScore()
    {
        int timeScore = Int32.Parse(TimeLeft.Seconds.ToString());
        int deathScore = 1000 - (Deaths * 100);
        int objectScore = 100 * CollectedObjects;

        if (deathScore < 0)
        {
            deathScore = 0;
        }

        return timeScore + deathScore + objectScore;
    }
}
