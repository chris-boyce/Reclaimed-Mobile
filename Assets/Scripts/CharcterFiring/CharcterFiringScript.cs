using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum WeaponTypes {Rifle, Minigun ,Shotgun ,RocketLauncher, Circular, Turret, Sniper , Landmine , Null  };


public class CharcterFiringScript : MonoBehaviour
{
    //Get all classes
    [Header("Gun Classes")]
    public List<GunCard> GunList = new List<GunCard>() {null, null};
    private BulletInstanitate BI;
    private AutoAimer AutoAimer;
    public Animator playerAnim;

    public Image[] WeaponIcons;

    private void Start()
    {
        BI = GetComponent<BulletInstanitate>();
        AutoAimer = GetComponent<AutoAimer>();
        SetBullet();
        SetIcon();
    }
    public void SetIcon()
    {
        WeaponIcons[0].sprite = GunList[0].Icon;
        WeaponIcons[1].sprite = GunList[1].Icon;

    }
    public void SetBullet()
    {
        foreach (var Guns in GunList)
        {
            Guns.BI = BI;
        }
    }

    void Update()
    {
        //Checks for gun equips
        if (AutoAimer.CanShoot != true || AutoAimer.EnemyCollisonsList.Count <= 0) return; //Stops running Update for Efficenty 
        transform.right = AutoAimer.EnemyCollisonsList[0].gameObject.transform.position - transform.position;
        for (int i = 0; i < GunList.Count; i++)
        {
            switch (GunList[i].WeaponType)
            {
                case WeaponTypes.Rifle:
                    GunList[i].Shoot();
                    break;
                case WeaponTypes.Minigun:
                    GunList[i].Shoot();
                    break;
                case WeaponTypes.Sniper:
                    GunList[i].Shoot();
                    break;
                case WeaponTypes.Circular:
                    GunList[i].Shoot();
                    break;
                case WeaponTypes.Shotgun:
                    GunList[i].Shoot();
                    break;
            }
        }

        playerAnim.SetBool("IsRight", false);
        playerAnim.SetBool("IsLeft", false);
        playerAnim.SetBool("IsDown", false);
        playerAnim.SetBool("IsUp", false);

        Debug.Log(transform.right);
        if(transform.right.x < 0)
        {
            playerAnim.SetBool("IsLeft", true);
        }
        if (transform.right.x > 0)
        {
            playerAnim.SetBool("IsRight", true);
        }
        if (transform.right.y > 0)
        {
            playerAnim.SetBool("IsUp", true);
        }
        if (transform.right.y < 0)
        {
            playerAnim.SetBool("IsDown", true);
        }
        //if (transform.rotation.z is >= -45 and >= -135)
        //{
        //    Debug.Log("Down");
        //    playerAnim.SetBool("IsDown", true);
        //}

    }

    public void UpgradeWeapon()
    {
        GunList[0].UpgradeWeapon();
        GunList[1].UpgradeWeapon();
    }

}
