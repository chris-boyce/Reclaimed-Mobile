using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEngine.GraphicsBuffer;

public class SavePlayerStats : MonoBehaviour
{
    public float SavedMovementSpeed;
    public float SavedHealth;
    public float SavedRange;
    public GunCard SavedPrimaryWeapon;
    public GunCard SavedSecondaryWeapon;
    public SaveScriptable SaveSO;

    public GameObject Player;
    private void Start()
    {
        SaveSO = Resources.Load<SaveScriptable>("SaveSO");
        SaveSO.SavedCurrentLevel = 1;
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

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(GunValues));
        using (StringWriter sw = new StringWriter()) 
        {
            xmlSerializer.Serialize(sw, SavedPrimaryWeapon.SavedGunValues);
            PlayerPrefs.SetString("GunValues", sw.ToString());
            Debug.Log(sw.ToString());
        }

    }
    public void UnloadFile()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(GunValues));
        string text = PlayerPrefs.GetString("GunValues");
        if(text.Length == 0)
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
          
        }
    }
}
