using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndRound : MonoBehaviour
{
    private GameObject[] EnemiesAlive;
    private LoadScene LoadScene;

    private bool GameEnded = false;
    private void Start()
    {
        LoadScene = GetComponent<LoadScene>();  
        InvokeRepeating("CheckEnemies", 1.0f, 5f);
    }
    void CheckEnemies()
    {
        EnemiesAlive = GameObject.FindGameObjectsWithTag("Enemy");
        if (EnemiesAlive.Length == 0 && GameEnded == false)//Checks for enemies alive 
        {
            LoadScene.OnSceneLoadAdditive();//Loads new scene
            GameEnded = true;
        }
    }


}
