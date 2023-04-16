using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public int output;
    public int currentlevel;
    public LoadScene ls;
    void Start()
    {
        SavePlayerStats Save = GameObject.FindGameObjectWithTag("SaveStat").GetComponent<SavePlayerStats>();
        currentlevel = PlayerPrefs.GetInt("LastLevelPlayed");
        output = Save.LevelDictionary[PlayerPrefs.GetInt("LastLevelPlayed") + 1];
        ls.LoadingSceneIndex = output;
    }


    void Update()
    {
        
    }
}
