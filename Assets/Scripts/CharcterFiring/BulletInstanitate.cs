using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletInstanitate : MonoBehaviour
{
    public Transform Firepoint1;
    public Transform Firepoint2;
    void Start()
    {
        Firepoint1 = transform.Find("FirePoint1");
        Firepoint2 = transform.Find("FirePoint2");
    }
    public void Shoot(GameObject Projectile, float Damage , float Range , float BulletVelocity, bool Penetration)
    {
        GameObject TempBullet = Instantiate(Projectile, Firepoint1.position, Firepoint1.rotation); //Spawns and give bullet stats
        BulletMovement TempBulletMovementScript = TempBullet.GetComponent<BulletMovement>();
        TempBulletMovementScript.Damage = Damage;
        TempBulletMovementScript.Range = Range;
        TempBulletMovementScript.BulletVelocity = BulletVelocity;
        TempBulletMovementScript.Penetration = Penetration;
    }

    public void ShootTwinShot(GameObject Projectile, float Damage, float Range, float BulletVelocity, bool Penetration)
    {
        GameObject TempBullet = Instantiate(Projectile, Firepoint1.position, Firepoint1.rotation); //Spawns and give bullet stats
        BulletMovement TempBulletMovementScript = TempBullet.GetComponent<BulletMovement>();
        TempBulletMovementScript.Damage = Damage;
        TempBulletMovementScript.Range = Range;
        TempBulletMovementScript.BulletVelocity = BulletVelocity;
        TempBulletMovementScript.Penetration = Penetration;

        GameObject TempBullet1 = Instantiate(Projectile, Firepoint2.position, Firepoint2.rotation); //Spawns and give bullet stats
        BulletMovement TempBulletMovementScript1 = TempBullet1.GetComponent<BulletMovement>();
        TempBulletMovementScript1.Damage = Damage;
        TempBulletMovementScript1.Range = Range;
        TempBulletMovementScript1.BulletVelocity = BulletVelocity;
        TempBulletMovementScript1.Penetration = Penetration;
    }

    public void ShootShotgun(GameObject Projectile, float Damage, float Range, float BulletVelocity, bool Penetration, int AmountofPellets, float SpreadAngleMax)
    {
        for (int i = 0; i < AmountofPellets; i++)
        {
            Quaternion ShotgunRot = transform.rotation * Quaternion.Euler(0, 0, Random.Range(-SpreadAngleMax, SpreadAngleMax));

            GameObject TempBullet = Instantiate(Projectile, transform.position, ShotgunRot); //Spawns and give bullet stats
            BulletMovement TempBulletMovementScript = TempBullet.GetComponent<BulletMovement>();
            TempBulletMovementScript.Damage = Damage;
            TempBulletMovementScript.Range = Range;
            TempBulletMovementScript.BulletVelocity = BulletVelocity;
            TempBulletMovementScript.Penetration = Penetration;
        }

    }
    public void ShootCircular(GameObject Projectile, float Damage, float Range, float BulletVelocity, bool Penetration, int AmountofPellets)
    {
        float CurrentAngle = 0;
        float IntervalOfAngle = 360 / AmountofPellets;
        for (int i = 0; i < AmountofPellets; i++)
        {
            
            Quaternion AngleOfShot = Quaternion.Euler(0, 0, CurrentAngle);
            CurrentAngle = CurrentAngle + IntervalOfAngle;
            GameObject TempBullet = Instantiate(Projectile, transform.position, AngleOfShot); //Spawns and give bullet stats
            BulletMovement TempBulletMovementScript = TempBullet.GetComponent<BulletMovement>();
            TempBulletMovementScript.Damage = Damage;
            TempBulletMovementScript.Range = Range;
            TempBulletMovementScript.BulletVelocity = BulletVelocity;
            TempBulletMovementScript.Penetration = Penetration;
        }

    }
    public void ShootRocket(GameObject Projectile, float Damage, float Range, float BulletVelocity, bool Penetration)
    {
        GameObject TempBullet = Instantiate(Projectile, transform.position, transform.rotation); //Spawns and give bullet stats
        RocketMovement TempBulletMovementScript = TempBullet.GetComponent<RocketMovement>();
        TempBulletMovementScript.Damage = Damage;
        TempBulletMovementScript.Range = Range;
        TempBulletMovementScript.BulletVelocity = BulletVelocity;
        TempBulletMovementScript.Penetration = Penetration;
    }

}
