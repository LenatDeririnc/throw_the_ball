using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;

public class LevelLoader : MonoBehaviour
{
    //public LevelData mainMenu;
    //public LevelData nextLevel;
    //public LevelData thisLevel;

    public string gameLogic = "GameLogic";
    public string mainMenu = "MainMenu";
    public string nextLevel = "";
    public string thisLevel = "";

    public void ResetData()
    {
        StaticData.ResetData();
    }

    public void Restart()
    {
        ResetData();
        //thisLevel.LoadLevel();
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, thisLevel, "Level_Restart");
        SceneManager.LoadScene(thisLevel);
        SceneManager.LoadScene(gameLogic, LoadSceneMode.Additive);
    }

    public void MainMenu()
    {
        ResetData();
        //mainMenu.LoadLevel();
        SceneManager.LoadScene(mainMenu);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, mainMenu, "Quit_Main_Menu");
    }

    public void NextLevel()
    {
        //nextLevel.LoadLevel();
        SceneManager.LoadScene(nextLevel);
        SceneManager.LoadScene(gameLogic, LoadSceneMode.Additive);
    }

    private void Awake()
    {
        StaticData.loader = this;
        if (StaticData.currentLevelData)
        {
            thisLevel = StaticData.currentLevelData.thisLevel;
            mainMenu = StaticData.currentLevelData.mainMenu;
            nextLevel = StaticData.currentLevelData.nextLevel;
        }
        if (StaticData.isFirstStart)
        {
            StaticData.isFirstStart = false;
            GameAnalytics.Initialize();
        }
        else
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, thisLevel, "Level_Progress", StaticData.CurrentBalls);
        }
    }
}
