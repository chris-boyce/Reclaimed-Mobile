using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;


public class SavePlayerStats : MonoBehaviour
{
    public float SavedMovementSpeed;
    public float SavedHealth;
    public float SavedRange;
    public GunCard SavedPrimaryWeapon;
    public GunCard SavedSecondaryWeapon;
    public int SavedLevel;
    public int SavedGold;
    public List<int> SavedPurchasedItemsID = new List<int>();
    public Dictionary<int, int> LevelDictionary = new Dictionary<int, int>();
    const string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789";
    public string UserName;

    public GameObject Player;
    private void Start()
    {
        LevelDictionary.Add(1,1);
        LevelDictionary.Add(2,7);
        LevelDictionary.Add(3,9);
        LevelDictionary.Add(4, 10);
        LevelDictionary.Add(5, 25);
        LevelDictionary.Add(6, 27);
        LevelDictionary.Add(7,28);
        LevelDictionary.Add(8, 29);
        LevelDictionary.Add(9,30);


        if (PlayerPrefs.GetString("PlayerID") == "")
        {
            for (int i = 0; i < 10; i++)
            {
                UserName += glyphs[UnityEngine.Random.Range(0, glyphs.Length)];
            }
            PlayerPrefs.SetString("PlayerID", UserName);
        }
        else
        {
            UserName = PlayerPrefs.GetString("PlayerID");
        }
        

        


        
        SaveGold();
        DontDestroyOnLoad(this.gameObject);
        
       
    }
    private void OnLevelWasLoaded(int level)
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            Player = GameObject.FindWithTag("Player");
            UnloadFile();
        }

    }

    public void SaveGold()
    {
        SavedGold = 1000;
        PlayerPrefs.SetInt("SavedGold", SavedGold);
    }

    public void SaveStats()
    {
        
        Debug.Log("Saved Stats");
        SavedMovementSpeed = Player.GetComponent<CharcterMovement>().MovementSpeed;
        SavedHealth = Player.GetComponent<CharcterHealth>().MaxHealth;
        SavedRange = Player.GetComponentInChildren<CircleCollider2D>().radius;
        SavedPrimaryWeapon = Player.GetComponentInChildren<CharcterFiringScript>().GunList[0];
        SavedSecondaryWeapon = Player.GetComponentInChildren<CharcterFiringScript>().GunList[1];
        SaveToFile();
    }
    public void SaveToFile()
    {
        PlayerPrefs.SetFloat("SaveMovementSpeed", SavedMovementSpeed);
        PlayerPrefs.SetFloat("SavedHealth", SavedHealth);
        PlayerPrefs.SetFloat("SavedRange", SavedRange);
        SavedLevel = PlayerPrefs.GetInt("SavedPlayerLevel");
        PlayerPrefs.SetInt("SavedPlayerLevel", SavedLevel);
        PlayerPrefs.SetInt("SavedGold", SavedGold);

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(GunValues));
        XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(GunValues));
        using (StringWriter sw = new StringWriter()) 
        {
            xmlSerializer.Serialize(sw, SavedPrimaryWeapon.SavedGunValues);
            PlayerPrefs.SetString("GunValues", sw.ToString());
            Debug.Log(sw.ToString());
        }

        using (StringWriter sw2 = new StringWriter())
        {
            xmlSerializer2.Serialize(sw2, SavedSecondaryWeapon.SavedGunValues);
            PlayerPrefs.SetString("GunValues2", sw2.ToString());
            Debug.Log(sw2.ToString());
        }

    }
    public void UnloadFile()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(GunValues));
        XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(GunValues));
        string text = PlayerPrefs.GetString("GunValues");
        string text2 = PlayerPrefs.GetString("GunValues2");
        if (text.Length == 0)
        {
            Debug.Log("No Saved Data");
           
        }
        else
        {
            using (var reader = new System.IO.StringReader(text))
            {
                GunValues temp = new GunValues();
                temp = xmlSerializer.Deserialize(reader) as GunValues;
                Debug.Log(temp.SavedWeaponType);
                Player.GetComponentInChildren<CharcterFiringScript>().LoadGunFromSave(temp);
            }

            using (var reader = new System.IO.StringReader(text2))
            {
                GunValues temp1 = new GunValues();
                temp1 = xmlSerializer2.Deserialize(reader) as GunValues;
                Debug.Log(temp1.SavedWeaponType);
                Player.GetComponentInChildren<CharcterFiringScript>().LoadGunFromSave2(temp1);
            }

        }
    }
}
