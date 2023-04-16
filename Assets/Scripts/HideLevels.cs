using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideLevels : MonoBehaviour
{
    public int currentlevel;
    public GameObject[] currentLevelsGameObject;
    void Awake()
    {
        currentlevel = PlayerPrefs.GetInt("SavedPlayerLevel");
        for (int i = 0; i < currentLevelsGameObject.Length; i++)
        {
            if (i >= currentlevel)
            {
                currentLevelsGameObject[i].SetActive(false);
            }
        }
    }

    
}
