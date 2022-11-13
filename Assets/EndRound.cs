using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRound : MonoBehaviour
{
    private void Start()
    {
        InvokeRepeating("CheckEnemies", 1.0f, 10f);
    }
    void CheckEnemies()
    {
        Debug.Log("Running");
    }


}
