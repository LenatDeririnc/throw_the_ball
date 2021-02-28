using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(thisLevel);
        SceneManager.LoadScene(gameLogic, LoadSceneMode.Additive);
    }

    public void MainMenu()
    {
        ResetData();
        //mainMenu.LoadLevel();
        SceneManager.LoadScene(mainMenu);
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
    }
}
