using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData
{
    public static int CurrentBalls = 0;
    public static LevelLoader loader;
    public static LevelData currentLevelData;

    public static void ResetData()
    {
        CurrentBalls = 0;
        loader = null;
        currentLevelData = null;
    }

    public static void ping()
    {
        Debug.Log("ping");
    }
}
