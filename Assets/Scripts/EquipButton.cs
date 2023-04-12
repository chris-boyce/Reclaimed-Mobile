using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class EquipButton : MonoBehaviour
{
    public GameObject Inventory;
    public List<GameObject> ItemList = new List<GameObject>();
    public int ItemCount;
    public ShopController ShopController;
    void Start()
    {
        Inventory = GameObject.FindGameObjectWithTag("ItemUI");
        ItemCount = 0;
        UpdateInventoryCheck();
    }

    

    public void UpdateInventoryCheck()
    {
        for (int i = 0; i < ItemList.Count; i++)
        {
            Destroy(ItemList[i]);
        }
        ItemList.Clear();

        for (int i = 0; i < ShopController.ShopItems.Length; i++)
        {
            if (ShopController.ShopItems[i].IsPurchased == true)
            {
                GameObject temp = Instantiate(Resources.Load("Button")) as GameObject;
                temp.transform.parent = Inventory.transform;
                temp.transform.Find("Image").GetComponent<Image>().sprite = ShopController.ShopItems[i].ItemImage;
                ItemList.Add(temp);
            }
        }

    }
    public void ItemEquipped()
    {
        for (int i = 0; i < ItemList.Count; i++)
        {
            ItemList[i].GetComponent<Image>().color = Color.grey;
        }
            
    }
}
