using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int LoadingSceneIndex;

    public void OnSceneLoad()
    {
        SceneManager.LoadScene(LoadingSceneIndex);
    }
    public void OnSceneLoadAdditive()
    {
        SceneManager.LoadScene(LoadingSceneIndex , LoadSceneMode.Additive);
    }
    public void OnSceneDeloadAdditive()
    {
        SceneManager.UnloadSceneAsync(LoadingSceneIndex);
    }

}
