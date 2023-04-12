using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum GunRarity
{
    Bronze = 0,Silver = 1,Gold = 2, Platinum = 3,Diamond = 4
}

public class GunClass : MonoBehaviour 
{
    public float Firerate;
    public int Level = 0;
    public GunRarity Rarity;
    public float Damage;
    public float BulletVelocity;
    public float Range;
    public bool Penetration;
    public float Timer;
    public GameObject Bullet;
    public BulletInstanitate BI;
    public virtual void Shoot()
    {
        Timer = Timer + Time.deltaTime;
        if (Timer > Firerate)
        {
            Debug.Log("Class Shooting");
            BI.Shoot(Bullet, Damage, Range, BulletVelocity, Penetration, BulletMovement.BulletTypes.Default);
            Timer = 0f;
        }
    }
    public virtual void Start()
    {
        BI = GetComponent<BulletInstanitate>();
        Bullet = Resources.Load("DefaultBullet") as GameObject;
    }
    public virtual void Update() 
    {

    }
    public virtual void UpgradeFirerate()
    {
        float TempRate = (Firerate / 100) * 10;
        Firerate = Firerate - TempRate;
    }

    public virtual void UpgradeWeaponLevel()
    {

    }

}


