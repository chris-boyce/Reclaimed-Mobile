using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunGunClass : GunClass
{
    public int AmountofPellets;
    public float SpreadAngleMax;
    public ShotgunGunClass() : base()
    {
        Firerate = 0.5f;
        Damage = 2f;
        BulletVelocity = 5f;
        Range = 5f;
        Penetration = false;
  
    }
    public override void Shoot()
    {
        Timer = Timer + Time.deltaTime;
        if (Timer > Firerate)
        {
            Debug.Log("Class Shooting");
            
            Timer = 0f;
        }
    }

}
