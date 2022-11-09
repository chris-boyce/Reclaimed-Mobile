using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class CharcterXP : MonoBehaviour
{
    private float TotalXP;
    private float XPTillNextLevel;
    private float CONSTANTXPAMOUNT = 100f;
    private int CurrentLevel = 1;


    private void Start()
    {
        XPTillNextLevel = 50f;
    }

    public void OnGiveXP(float GivenXP)
    {
        //XP is from the EnemyHealth OnEnemyDeath (DropXP Function)
        Debug.Log("CurrentXP" + TotalXP);
        TotalXP += GivenXP;
        if(TotalXP >= XPTillNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        Debug.Log("Level UP" + CurrentLevel);
        CurrentLevel++;
        XPTillNextLevel = (CurrentLevel/2) * CONSTANTXPAMOUNT;
        Debug.Log("XP Till next Level = " + XPTillNextLevel);
        TotalXP = 0;
        //TODO Add bloody Overclock / Upgrade System
    }
}
