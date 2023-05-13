using System;

public static class ScoreHandler
{
    static bool ArcadeMode = false;
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

    public static void Collected()
    {
        CollectedObjects++;
    }

    public static void SetCollectedToZero()
    {
        CollectedObjects = 0;
    }

    public static void InitArcade()
    {
        ArcadeMode = false;
    }

    public static void SetArcade()
    {
        if (ArcadeMode)
        {
            ArcadeMode = false;
        }
        else
        {
            ArcadeMode = true;
        }
    }

    public static bool IsArcade()
    {
        return ArcadeMode;
    }

    public static TimeSpan GetTime() => (TotalTime - TimeLeft);

    public static string GetDeaths() => Deaths.ToString();

    public static string GetCollected() => CollectedObjects.ToString();

    public static string GetArcade() => ArcadeMode ? "1000" : "0";

    public static int CalculateScore()
    {
        int timeScore = Int32.Parse(TimeLeft.Seconds.ToString());
        int deathScore = 1000 - (Deaths * 100);
        int objectScore = 100 * CollectedObjects;
        int arcadeScore = ArcadeMode ? 1000 : 0;

        if (deathScore < 0)
        {
            deathScore = 0;
        }

        int totalScore = timeScore + deathScore + objectScore + arcadeScore;

        return totalScore;
    }
}
