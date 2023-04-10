using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class WeaponUnlockBox : MonoBehaviour
{
    //public WeaponTypes UnlockedWeapon;
    public GunCard[] AllGuns;
    public GunCard UnlockedGun;
    public WeaponUpgrades WeaponUpgrades;
    public CharcterFiringScript CharcterFiringScript;
    public GameObject UI;

    public TextMeshProUGUI PrimaryWeaponText;
    public TextMeshProUGUI SecondaryWeaponText;
    public TextMeshProUGUI NewWeaponText;


    private void Start()
    {
        AllGuns = Resources.LoadAll<GunCard>("GunCards");
        UnlockedGun = AllGuns[Random.Range(0, AllGuns.Length)];
        CharcterFiringScript = FindObjectOfType<CharcterFiringScript>();
        UI.SetActive(false);
    }
    public void ChangePrimaryWeapon()
    {
        CharcterFiringScript.GunList[0] = UnlockedGun;
        CharcterFiringScript.SetBullet();
        CharcterFiringScript.SetIcon();
    }
    public void ChangeSecondaryWeapon()
    {
        CharcterFiringScript.GunList[1] = UnlockedGun;
        CharcterFiringScript.SetBullet();
        CharcterFiringScript.SetIcon();
    }
    public void ToggleUI()
    {
        PrimaryWeaponText.text = CharcterFiringScript.GunList[0].Name.ToString();
        if (CharcterFiringScript.GunList[1] != null )
        {
            SecondaryWeaponText.text = CharcterFiringScript.GunList[1].Name.ToString();
        }
        



        NewWeaponText.text = UnlockedGun.Name.ToString();
        UI.SetActive(true);
    }



}
