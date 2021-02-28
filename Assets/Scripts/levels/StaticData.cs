using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData
{
    public static int CurrentBalls = 0;
    public static LevelLoader loader;
    public static LevelInfo currentLevelData;

    public static void ResetData()
    {
        CurrentBalls = 0;
        loader = null;
        currentLevelData = null;
    }
}
