using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyController : MonoBehaviour
{
    public GameObject SaveStats;


    void Start()
    {
        Time.timeScale = 1.0f;
        SavePlayerStats[] others = FindObjectsOfType<SavePlayerStats>();
        if (others.Length > 0)
        {

        }
        else
        {
            Instantiate(SaveStats);
        }

    }


}
