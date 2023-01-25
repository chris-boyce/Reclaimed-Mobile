using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "Guns", menuName = "Guns")]
public class GunCard : ScriptableObject
{
    [Header("Gun Info")] public string Name;
    public string Description;
    public WeaponTypes WeaponType;

    [Header("Gun Stats")] //Stats Set in Editor cannot be edited in code becasue wouldnt reset as it is a Scriptable Object
    public float Damage;
    public float FireRate;
    public float BulletVelocity;
    public float Range;
    public bool Penetration;
    public int AmountOfPellets;
    public float SpreadAngleMax;
    [Header("Gun GOs")]  
    public GameObject Bullet; //Bullet the Gun Produces
    public GameObject Gun; //What the Gun Looks like in the Hands
    public BulletInstanitate BI; //BI Is Filled From the Firing Script
    public Sprite Icon;


    //RunTime variables that are editable by the code 
    private float Timer;
    private float RT_Damage;
    private float RT_FireRate;  
    private float RT_BulletVelocity;    
    private float RT_Range; 


    private void OnEnable()
    {
        RT_Damage = Damage;
        RT_FireRate = FireRate;
        RT_BulletVelocity  = BulletVelocity;
        RT_Range = Range;
    }

    public void Shoot()
    {
        Timer = Timer + Time.deltaTime;
        if (Timer > RT_FireRate)
        {
            if (WeaponType == WeaponTypes.Shotgun)
            {
                BI.ShootShotgun(Bullet, RT_Damage, RT_Range, RT_BulletVelocity, Penetration, AmountOfPellets, SpreadAngleMax);
            }
            else if (WeaponType == WeaponTypes.Circular)
            {
                BI.ShootCircular(Bullet, RT_Damage, RT_Range, RT_BulletVelocity, Penetration, AmountOfPellets);
            }
            else
            {
                Debug.Log(RT_Damage.ToString());
                BI.Shoot(Bullet, RT_Damage, RT_Range, RT_BulletVelocity, Penetration);
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


}
