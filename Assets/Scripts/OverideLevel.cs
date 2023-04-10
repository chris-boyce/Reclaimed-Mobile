using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverideLevel : MonoBehaviour
{
    public int currentLevel;
    LoadScene loadScene;
    void Start()
    {
        loadScene = GetComponent<LoadScene>();

        

        
        
        loadScene.LoadingSceneIndex = PlayerPrefs.GetInt("SavedPlayerLevel");
    }

    void Update()
    {
        
    }
}
