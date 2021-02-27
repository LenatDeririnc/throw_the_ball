using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public LevelData[] scenes;

    public void ChangeFullyToLevel(int index)
    {
        for (int i = 0; i < scenes[index].LoadingScenes.Length; i++)
        {
            var mode = LoadSceneMode.Additive;
            if (i == 0) mode = LoadSceneMode.Single;
            SceneManager.LoadScene(scenes[index].LoadingScenes[i].name, mode);
        }
    }
}
