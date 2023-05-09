using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[System.Serializable]
public class GunValues
{
    public WeaponTypes SavedWeaponType;
    public float SavedDamage;
    public float SavedFireRate;
    public float SavedBulletVelocity;
}

[CreateAssetMenu(fileName = "Guns", menuName = "Guns")]
public class GunCard : ScriptableObject
{
    public GunValues SavedGunValues;
    [Header("Gun Info")]
    public string Name;
    public string Description;
    public WeaponTypes WeaponType;
    public BulletMovement.BulletTypes BulletMovementType;

    [Header("Gun Stats")] //Stats Set in Editor cannot be edited in code becasue wouldnt reset as it is a Scriptable Object
    public float Damage;
    public float FireRate;
    public float BulletVelocity;
    public float Range;
    public bool Penetration;
    public int AmountOfPellets;
    public float SpreadAngleMax;
    public AudioClip GunShot;
    [Header("Gun GOs")]  
    public GameObject Bullet; //Bullet the Gun Produces
    public GameObject Gun; //What the Gun Looks like in the Hands
    public BulletInstanitate BI; //BI Is Filled From the Firing Script
    public Sprite Icon;
    public bool TwinShot = false;


    //RunTime variables that are editable by the code 
    private float Timer;
    private float RT_Damage;
    private float RT_FireRate;  
    private float RT_BulletVelocity;    
    private float RT_Range;
    private GameObject[] AllBullets;

    private void OnEnable()
    {
        RT_Damage = Damage;
        RT_FireRate = FireRate;
        RT_BulletVelocity  = BulletVelocity;
        RT_Range = Range;
        SaveValues();
    }

    public void Shoot()
    {
        Timer = Timer + Time.deltaTime;
        if (Timer > RT_FireRate)
        {
            SoundController.PlaySound(GunShot);
            if (WeaponType == WeaponTypes.Shotgun)
            {
                if (TwinShot == false)
                {
                    BI.ShootShotgun(Bullet, RT_Damage, RT_Range, RT_BulletVelocity, Penetration, AmountOfPellets, SpreadAngleMax, BulletMovementType);
                }
                else
                {
                    BI.ShootShotgun(Bullet, RT_Damage, RT_Range, RT_BulletVelocity, Penetration, AmountOfPellets * 2, SpreadAngleMax, BulletMovementType);
                }
                    
            }
            else if (WeaponType == WeaponTypes.Circular)
            {
                if (TwinShot == false)
                {
                    BI.ShootCircular(Bullet, RT_Damage, RT_Range, RT_BulletVelocity, Penetration, AmountOfPellets, BulletMovementType);
                }
                else
                {
                    BI.ShootCircular(Bullet, RT_Damage, RT_Range, RT_BulletVelocity, Penetration, AmountOfPellets * 2, BulletMovementType);
                }
                
            }
            else if (WeaponType == WeaponTypes.RocketLauncher)
            {
                BI.ShootRocket(Bullet, RT_Damage,RT_Range,RT_BulletVelocity,Penetration, BulletMovementType);
            }
            else
            {
                if (TwinShot == false)
                {
                    if (Bullet != null)
                    {
                        BI.Shoot(Bullet, RT_Damage, RT_Range, RT_BulletVelocity, Penetration, BulletMovementType);
                    }
                }
                else
                {
                    if (Bullet != null)
                    {
                        BI.ShootTwinShot(Bullet, RT_Damage, RT_Range, RT_BulletVelocity, Penetration, BulletMovementType);
                    }
                        
                }
                
                
            }
            Timer = 0f;
        }
    }

    public void UpgradeWeapon()
    {
        Debug.Log(Damage.ToString() + RT_Damage.ToString());
        RT_Damage = Multiplier(RT_Damage, 1.5f);
        RT_FireRate = Reducer(RT_FireRate, 0.8f);


    }
    private float Multiplier(float Input, float Multiplier)
    {
        return Input * Multiplier;
    }

    private float Reducer(float Input, float Reducer)
    {
        return Reducer * Input;
    }
    public void SaveValues()
    {
        Debug.Log("has Run saved");
        SavedGunValues.SavedWeaponType = WeaponType;
        SavedGunValues.SavedBulletVelocity = BulletVelocity;
        SavedGunValues.SavedDamage = Damage;
        SavedGunValues.SavedFireRate = FireRate;
    }    


}
