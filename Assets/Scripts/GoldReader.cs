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

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Players Gold : " + PlayerPrefs.GetInt("SavedGold").ToString();
    }

}
