using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public LevelData mainMenu;
    public LevelData nextLevel;
    public LevelData thisLevel;

    public void ResetData()
    {
        StaticData.ResetData();
    }

    public void Restart()
    {
        ResetData();
        thisLevel.LoadLevel();
    }

    public void MainMenu()
    {
        ResetData();
        mainMenu.LoadLevel();
    }

    public void NextLevel()
    {
        nextLevel.LoadLevel();
    }

    private void Awake()
    {
        StaticData.loader = this;
        if (StaticData.currentLevelData)
        {
            thisLevel = StaticData.currentLevelData.thisLevel;
            mainMenu = StaticData.currentLevelData.mainMenu;
            if (nextLevel == null)
                nextLevel = StaticData.currentLevelData.nextLevel;
        }
    }
}
