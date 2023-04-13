using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndRound : MonoBehaviour
{
    public GameObject[] EnemiesAlive;
    public LoadScene LoadScene;
    public SavePlayerStats SaveStats;
    public int LevelNum;

    private bool GameEnded = false;
    private void Start()
    {
        LoadScene = GetComponent<LoadScene>();  
        InvokeRepeating("CheckEnemies", 20.0f, 5f);
        SaveStats = GameObject.FindWithTag("SaveStat").GetComponent<SavePlayerStats>();
    }
    void CheckEnemies()
    {
        EnemiesAlive = GameObject.FindGameObjectsWithTag("Enemy");
        if (EnemiesAlive.Length == 0 && GameEnded == false)//Checks for enemies alive 
        {
            PlayerPrefs.SetInt("SavedPlayerLevel", LevelNum);
            Debug.Log("Should Have Ended");
            SaveStats.SaveStats();
            LoadScene.OnSceneLoadAdditive();//Loads new scene
            GameEnded = true;
        }
    }
  


}
