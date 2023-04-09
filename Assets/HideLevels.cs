using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideLevels : MonoBehaviour
{
    public int currentlevel;

    void Awake()
    {
        currentlevel = PlayerPrefs.GetInt("SavedPlayerLevel");
        GameObject[] currentLevelsGameObject = GameObject.FindGameObjectsWithTag("ItemUI");
        for (int i = 0; i < currentLevelsGameObject.Length; i++)
        {
            if (i >= currentlevel)
            {
                currentLevelsGameObject[i].SetActive(false);
            }
        }
    }

    
}
