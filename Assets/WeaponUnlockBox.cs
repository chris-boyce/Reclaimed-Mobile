using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class WeaponUnlockBox : MonoBehaviour
{
    public WeaponTypes UnlockedWeapon;
    public WeaponUpgrades WeaponUpgrades;
    public CharcterFiringScript CharcterFiringScript;
    public GameObject UI;

    public TextMeshProUGUI PrimaryWeaponText;
    public TextMeshProUGUI SecondaryWeaponText;
    public TextMeshProUGUI NewWeaponText;


    private void Start()
    {
        UI.SetActive(false);
        UnlockedWeapon = (WeaponTypes)Random.Range(0, System.Enum.GetValues(typeof(WeaponTypes)).Length - 1);
        Debug.Log(UnlockedWeapon.ToString());
    }
    public void ChangePrimaryWeapon()
    {
        WeaponUpgrades.ChangePrimary(UnlockedWeapon);
    }
    public void ChangeSecondaryWeapon()
    {
        WeaponUpgrades.ChangeSecondary(UnlockedWeapon);
    }
    public void ToggleUI()
    {
        PrimaryWeaponText.text = CharcterFiringScript.Primary.ToString();
        SecondaryWeaponText.text = CharcterFiringScript.Secondary.ToString();
        NewWeaponText.text = UnlockedWeapon.ToString();
        UI.SetActive(true);
    }



}
