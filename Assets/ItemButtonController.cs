using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemButtonController : MonoBehaviour
{
    public bool IsPurchased;
    public bool IsEqiuped;
    public Color ButtonColor;
    public int ItemID;
    public ShopController ShopController;

    public void ItemBrought()
    {
        ShopController = GameObject.FindGameObjectWithTag("ShopController").GetComponent<ShopController>();
        if (ShopController.ShopItems[ItemID].Price <= PlayerPrefs.GetInt("SavedGold"))
        {
            GetComponent<Image>().color = Color.green;
            transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "Purchased";
            ShopController = GameObject.FindGameObjectWithTag("ShopController").GetComponent<ShopController>();
            ShopController.ItemBrought(ItemID);
        }
        
    }

    public void AllReadyHave()
    {
        GetComponent<Image>().color = Color.green;
        transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "Purchased";
        GetComponent<Button>().enabled = false;

    }
    
}
