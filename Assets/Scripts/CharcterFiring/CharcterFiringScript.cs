using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponTypes {Rifle, Minigun ,Shotgun ,RocketLauncher, Circular, Turret, Sniper , Landmine , Null  };


public class CharcterFiringScript : MonoBehaviour
{

    [Header("Gun Classes")]
    public DefaultGunClass m_defaultGun;
    public MinigunGunClass m_minigun;
    public SniperGunClass m_sniper;
    public ShotgunGunClass m_shotgun;
    public CircularGunClass m_circular;

    [Header("Players Equipped Weapons")]
    public WeaponTypes Primary;
    public WeaponTypes Secondary;

    [Header("Referenced Scripts")]
    private BulletInstanitate BI;
    public AutoAimer AutoAimer;



    private void Start()
    {
        BI = GetComponent<BulletInstanitate>();
        Primary = WeaponTypes.Null;
        Secondary = WeaponTypes.Null;
        //TODO SAVE THIS AND LOAD FROM THE SAVE
    }

    void Update()
    {
        if (AutoAimer.CanShoot == true && AutoAimer.EnemyCollisonsList.Count > 0)
        {
            transform.right = AutoAimer.EnemyCollisonsList[0].gameObject.transform.position - transform.position;
            if (Primary == WeaponTypes.Rifle || Secondary == WeaponTypes.Rifle)
            {
                m_defaultGun.Shoot();
            }
            if (Primary == WeaponTypes.Minigun || Secondary == WeaponTypes.Minigun)
            {
                m_minigun.Shoot();
            }
            if (Primary == WeaponTypes.Sniper || Secondary == WeaponTypes.Sniper)
            {
                m_sniper.Shoot();
            }
            if (Primary == WeaponTypes.Shotgun || Secondary == WeaponTypes.Shotgun)
            {
                m_shotgun.Shoot();
            }
            if (Primary == WeaponTypes.Circular || Secondary == WeaponTypes.Circular)
            {
                m_circular.Shoot();
            }
        }


    }
    public void UpgradeFirerate()
    {
        m_defaultGun.UpgradeFirerate();
        m_minigun.UpgradeFirerate();
        m_sniper.UpgradeFirerate();
        m_shotgun.UpgradeFirerate();
        m_circular.UpgradeFirerate();
    }
}
