using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public GameObject[] ShopUI;
    public ShopItem[] ShopItems;
    public SavePlayerStats savedPlayerStats;
    public EquipButton equipButton;
    void Start()
    {
        savedPlayerStats = GameObject.FindGameObjectWithTag("SaveStat").GetComponent<SavePlayerStats>();
        for (int i = 0; i < ShopUI.Length; i++)
        {
            ShopUI[i].transform.Find("Image").GetComponent<Image>().sprite = ShopItems[i].ItemImage;
            ShopUI[i].transform.Find("ShopText").GetComponent<TextMeshProUGUI>().text = ShopItems[i].Price.ToString() + " Gold";
            ShopUI[i].transform.Find("Name").GetComponent<TextMeshProUGUI>().text = ShopItems[i].ItemName;
        }

        for (int i = 0; i < ShopItems.Length; i++)
        {
            if (ShopItems[i].IsPurchased)
            {
                ShopUI[i].transform.Find("Button").GetComponent<ItemButtonController>().AllReadyHave();
            }
        }
        for (int i = 0; i < savedPlayerStats.SavedPurchasedItemsID.Count; i++)
        {
            ShopUI[savedPlayerStats.SavedPurchasedItemsID[i]].transform.Find("Button").GetComponent<ItemButtonController>().AllReadyHave();
            ShopItems[savedPlayerStats.SavedPurchasedItemsID[i]].IsPurchased = true;
            equipButton.UpdateInventoryCheck();

        }




    }

    public void ItemBrought(int ID)
    {
        ShopItems[ID].IsPurchased = true;
        savedPlayerStats.SavedPurchasedItemsID.Add(ID);
        int current = PlayerPrefs.GetInt("SavedGold");
        current = current - ShopItems[ID].Price;
        PlayerPrefs.SetInt("SavedGold", current);
    }

}
[System.Serializable]
public struct ShopItem
{
    public string ItemName;
    public Sprite ItemImage;
    public bool IsPurchased;
    public int Price;
    public bool IsEquipped;
    public int ItemID;

    public ShopItem(string Name,Sprite Image, bool Purchased, int price, bool Equipped, int ID)
    {
        this.ItemName = Name;
        this.ItemImage = Image;
        this.IsPurchased = Purchased;
        this.Price = price;
        this.IsEquipped = Equipped;
        this.ItemID = ID;
    }
}
