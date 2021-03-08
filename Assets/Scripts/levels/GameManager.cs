using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager self;

    public Canvas GameOverUI;
    public TMP_Text FoodCounter;
    public LevelLoader loader;
    public SphereSpawn spawner;
    public AudioSounds aud;

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
            FoodCounter.text = StaticData.CurrentBalls.ToString();
            if (StaticData.CurrentBalls <= 0)
            {
                StaticData.CurrentBalls = 0;
                GameOverTimer = StartCoroutine(GameOverCoroutine());
            }
        }
    }

    private IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(3);
        GameOver();
    }

    public void NextLevel()
    {
        StaticData.loader.NextLevel();
    }

    public void GameOver()
    {
        if (GameOverUI != null) 
            GameOverUI.gameObject.SetActive(true);
        aud.Loose();
    }

    private void Awake()
    {
        self = this;
        if (StaticData.currentLevelData)
        {
            aud.audioSource.clip = StaticData.currentLevelData.embient;
            aud.audioSource.loop = true;
            aud.audioSource.Play();
            FoodCounter.text = StaticData.CurrentBalls.ToString();
        }
    }
}
