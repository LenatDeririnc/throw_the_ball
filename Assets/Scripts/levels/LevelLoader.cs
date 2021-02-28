using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public LevelData nextLevel;

    public void ResetData()
    {
        StaticData.ResetData();
    }

    public void NextLevel()
    {
        nextLevel.LoadLevel();
    }

    private void Awake()
    {
        StaticData.loader = this;
        if (StaticData.currentLevelData && nextLevel == null)
            nextLevel = StaticData.currentLevelData.nextLevel;
    }
}
