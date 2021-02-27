using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager self;

    public Canvas GameOverUI;
    public LevelLoader loader;

    Coroutine GameOverTimer;
    private int _currentScore = 0;
    public int CurrentScore
    {
        get => _currentScore;
        set
        {
            _currentScore = value;
            if (_currentScore >= StaticData.currentLevelData.TargetsCount)
            {
                if (GameOverTimer != null)
                    StopCoroutine(GameOverTimer);
                NextLevel();
            }
        }
    }
    public int CurrentBalls
    {
        get => StaticData.CurrentBalls;
        set
        {
            StaticData.CurrentBalls = value;
            if (StaticData.CurrentBalls <= 0)
            {
                StaticData.CurrentBalls = 0;
                GameOver();
            }
        }
    }

    public void NextLevel()
    {
        Debug.Log("Next level");
        StaticData.loader.nextLevel.LoadLevel();
    }

    public void GameOver()
    {
        GameOverTimer = StartCoroutine(GameOverEnumerator());
    }

    private IEnumerator GameOverEnumerator()
    {
        yield return new WaitForSeconds(3);
        if (GameOverUI) GameOverUI.enabled = true;
        Debug.Log("Game Over");
    }

    private void Awake()
    {
        self = this;
    }
}
