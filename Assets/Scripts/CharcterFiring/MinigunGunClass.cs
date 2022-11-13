using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunGunClass : GunClass
{
    public MinigunGunClass() : base()
    {
        Firerate = 0.1f;
        Damage = 5f;
        BulletVelocity = 7f;
        Range = 5f;
        Penetration = false;
    }
    public override void Shoot()
    {
        base.Shoot();
    }

}
