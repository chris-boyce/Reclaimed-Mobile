using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularGunClass : GunClass
{
    public int AmountofPellets;
    public CircularGunClass() : base()
    {
        Firerate = 0.5f;
        Damage = 10f;
        BulletVelocity = 3f;
        Range = 3f;
        Penetration = false;
    }
    public override void Shoot()
    {
        
    }
}
