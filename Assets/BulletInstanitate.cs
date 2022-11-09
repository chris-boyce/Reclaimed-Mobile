using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletInstanitate : MonoBehaviour
{
    public void Shoot(GameObject Projectile, float Damage , float Range , float BulletVelocity, bool Penetration)
    {
        GameObject TempBullet = Instantiate(Projectile, transform.position, transform.rotation); //Spawns and give bullet stats
        BulletMovement TempBulletMovementScript = TempBullet.GetComponent<BulletMovement>();
        TempBulletMovementScript.Damage = Damage;
        TempBulletMovementScript.Range = Range;
        TempBulletMovementScript.BulletVelocity = BulletVelocity;
        TempBulletMovementScript.Penetration = Penetration;
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
}
