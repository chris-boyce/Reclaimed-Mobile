using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGunClass : GunClass
{
    public DefaultGunClass() : base()
    {


        Firerate = 0.2f;
        Damage = 10f;
        BulletVelocity = 5f;
        Range = 10f;
        Penetration = false;

    }
    public override void Shoot()
    {
        base.Shoot();
    }
}
