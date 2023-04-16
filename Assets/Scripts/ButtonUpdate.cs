using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUpdate : MonoBehaviour
{
    public int EquipedItemID;
    public void ButtonCheck()
    {
        GameObject.FindGameObjectWithTag("InventoryController").GetComponent<EquipButton>().ItemEquipped();
        PlayerPrefs.SetInt("EquipItemID", EquipedItemID);
        GetComponent<Image>().color = Color.green;
    }
}
