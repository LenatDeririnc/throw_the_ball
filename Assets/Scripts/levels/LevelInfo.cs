using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelInfo : MonoBehaviour
{
    public string LevelName;
    public int LevelDificulty;
    public int AddingProjectiles;
    public int TargetsCount;
    //public LevelData nextLevel;
    //public LevelData mainMenu;
    //public LevelData thisLevel;
    public string nextLevel;
    public string mainMenu;
    public string thisLevel;
    public AudioClip embient;

    private void Awake()
    {
        StaticData.currentLevelData = this;
        StaticData.CurrentBalls += AddingProjectiles;
    }
}
