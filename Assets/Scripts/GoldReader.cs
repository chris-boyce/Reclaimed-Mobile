using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldReader : MonoBehaviour
{
    public SavePlayerStats SaveStats;
    void Start()
    {
        SaveStats = GameObject.FindGameObjectWithTag("SaveStat").GetComponent<SavePlayerStats>();
    }

    public void AddGold(int Amount)
    {
        PlayerPrefs.SetInt("SavedGold", PlayerPrefs.GetInt("SavedGold") + Amount);
    }
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Players Gold : " + PlayerPrefs.GetInt("SavedGold").ToString();
    }

}
