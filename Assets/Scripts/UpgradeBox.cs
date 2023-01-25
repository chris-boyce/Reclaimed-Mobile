using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeBox : MonoBehaviour //Card Upgrade System
{
    public UpgradeCard[] AllCards;

    public UpgradeCard Card1;
    public UpgradeCard Card2;

    public UpgradePlayer PlayersUpgrade;

    public GameObject UI;
    public TextMeshProUGUI CardHeading1;
    public TextMeshProUGUI CardDescription1;
    public TextMeshProUGUI CardHeading2;
    public TextMeshProUGUI CardDescription2;

    private void Start()
    {
        AllCards = Resources.LoadAll<UpgradeCard>("UpgradeCards");
        ShuffleCards();

    }
    private void OnEnable()
    {
        UI.SetActive(false);
    }

    public void ToggleUI()
    {
        UI.SetActive(true);
        CardHeading1.text = Card1.UpgradeName;
        CardHeading2.text = Card2.UpgradeName;
        CardDescription1.text = Card1.UpgradeDescription;
        CardDescription2.text = Card2.UpgradeDescription;
    }
    public void DisableUI()
    {
        ShuffleCards();
        UI.SetActive(false);
        this.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
    private void ShuffleCards()
    {
        Card1 = AllCards[Random.Range(0, AllCards.Length)];
        Card2 = AllCards[Random.Range(0, AllCards.Length)];
    }

    public void Card1Pressed()
    {
        switch(Card1.UpgradeCat)
        {
            case UpgradeEnum.NULL:
                break;
            case UpgradeEnum.Range:
                PlayersUpgrade.UpgradeRange();
                break;
            case UpgradeEnum.UpgradeWeapon:
                PlayersUpgrade.UpgradeWeapon();
                break;
            case UpgradeEnum.MovementSpeed:
                PlayersUpgrade.UpgradeMovementSpeed();
                break;
        }
    }
    public void Card2Pressed()
    {
        switch (Card2.UpgradeCat)
        {
            case UpgradeEnum.NULL:
                break;
            case UpgradeEnum.Range:
                PlayersUpgrade.UpgradeRange();
                break;
            case UpgradeEnum.UpgradeWeapon:
                PlayersUpgrade.UpgradeWeapon();
                break;
            case UpgradeEnum.MovementSpeed:
                PlayersUpgrade.UpgradeMovementSpeed();
                break;
        }
    }
}
