using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor.Callbacks;
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SceneInfoObject", order = 1)]
public class LevelData : ScriptableObject
{
    public Object[] LoadingScenes;

    public void LoadLevel()
    {
        for (int i = 0; i < LoadingScenes.Length; i++)
        {
            LoadSceneMode loadMode = LoadSceneMode.Additive;
            if (i == 0) loadMode = LoadSceneMode.Single;
            SceneManager.LoadScene(LoadingScenes[i].name, loadMode);
        }
    }

#if UNITY_EDITOR

    [OnOpenAssetAttribute(1)]
    public static bool LoadScenes(int instanceID, int line)
    {
        LevelData data = EditorUtility.InstanceIDToObject(instanceID) as LevelData;
        if (data == null)
            return false;

        if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            return false;

        for (int i = 0; i < data.LoadingScenes.Length; i++)
        {
            var openMode = OpenSceneMode.Additive;
            if (i == 0) openMode = OpenSceneMode.Single;
            EditorSceneManager.OpenScene(AssetDatabase.GetAssetPath(data.LoadingScenes[i]), openMode);
        }

        return true;
    }
#endif
}
