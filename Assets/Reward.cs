using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reward : MonoBehaviour
{
    public int LastDate;
    public int Day;
    public GameObject Button;

    void Start()
    {
        Day = PlayerPrefs.GetInt("Day");
        LastDate = PlayerPrefs.GetInt("LastDate");
        
    }

    void Update()
    {
        if (LastDate != System.DateTime.Now.Day)
        {
            Button.SetActive(true);
        }
        else
        {
            Button.SetActive(false);
        }
    }
    public void Rewards()
    {
        if (Day == 0)
        {
            PlayerPrefs.SetInt("SavedGold", PlayerPrefs.GetInt("SavedGold") + 5);
        }
        if (Day == 1)
        {
            PlayerPrefs.SetInt("SavedGold", PlayerPrefs.GetInt("SavedGold") + 10);
        }
        if (Day == 2)
        {
            PlayerPrefs.SetInt("SavedGold", PlayerPrefs.GetInt("SavedGold") + 10);
        }
        if (Day == 3)
        {
            PlayerPrefs.SetInt("SavedGold", PlayerPrefs.GetInt("SavedGold") + 15);
        }
        if (Day >= 4)
        {
            PlayerPrefs.SetInt("SavedGold", PlayerPrefs.GetInt("SavedGold") + 20);
        }
    }

    public void GetRewards()
    {
        if (LastDate != System.DateTime.Now.Day + 1)
        {
            Rewards();
            LastDate = System.DateTime.Now.Day;
            PlayerPrefs.SetInt("LastDate", LastDate);
            Debug.Log("Reward");
            Day = 0;
            PlayerPrefs.SetInt("Day", Day);
        }
        else
        {
            LastDate = System.DateTime.Now.Day;
            PlayerPrefs.SetInt("LastDate", LastDate);
            Day = Day + 1;
            Rewards();
            PlayerPrefs.SetInt("Day", Day);
        }
        
    }

}
