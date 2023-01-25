using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunGunClass : GunClass
{
    public MinigunGunClass() : base()
    {
        Firerate = 0.1f;
        Level = 0;
        Damage = 5f;
        BulletVelocity = 7f;
        Range = 5f;
        Penetration = false;
        Rarity = GunRarity.Bronze;
    }


    public override void Shoot()
    {
        base.Shoot();
    }

    public override void UpgradeWeaponLevel()
    {
        Level = Level + 1;
        Rarity = (GunRarity)Level;
        
    }

    

}
