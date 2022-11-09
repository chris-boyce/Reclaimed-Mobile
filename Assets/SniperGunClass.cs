using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGunClass : GunClass
{
    public SniperGunClass() : base()
    {
        Firerate = 0.5f;
        Damage = 25f;
        BulletVelocity = 10f;
        Range = 20f;
        Penetration = false;
    }
    public override void Shoot()
    {
        base.Shoot();
    }
}
