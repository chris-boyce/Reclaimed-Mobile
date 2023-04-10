using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUpdate : MonoBehaviour
{
    public void ButtonCheck()
    {
        GameObject.FindGameObjectWithTag("InventoryController").GetComponent<EquipButton>().ItemEquipped();
        GetComponent<Image>().color = Color.green;
    }
}
