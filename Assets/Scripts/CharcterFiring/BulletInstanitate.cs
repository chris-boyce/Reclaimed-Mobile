using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletInstanitate : MonoBehaviour
{
    public Transform Firepoint1;
    public Transform Firepoint2;

    public int BulletID;
    public BulletPool Bullets;
    public bool isEnemy;
    

    void Start()
    {
        Firepoint1 = transform.Find("FirePoint1");
        Firepoint2 = transform.Find("FirePoint2");
        if (isEnemy)
        {
            Bullets = GameObject.FindGameObjectWithTag("EnemyBulletPool").GetComponent<BulletPool>();
        }
        else
        {
            Bullets = GameObject.FindGameObjectWithTag("BulletPool").GetComponent<BulletPool>();
        }
        
    }

    public void Shoot(GameObject Projectile, float Damage , float Range , float BulletVelocity, bool Penetration, BulletMovement.BulletTypes BulletType)
    {
        GameObject bullet = Bullets.GetBullet();
        bullet.transform.position = Firepoint1.transform.position;
        bullet.transform.rotation = Firepoint1.transform.rotation;
        BulletMovement TempBulletMovementScript = bullet.GetComponent<BulletMovement>();
        BulletInfo(bullet, TempBulletMovementScript,Damage,Range,BulletVelocity,Penetration,BulletType);
    }

    private void BulletInfo(GameObject Bullet, BulletMovement BM, float Damage, float Range, float BulletVelocity, bool Penetration, BulletMovement.BulletTypes BulletType)
    {
        BM.BulletType = BulletType;
        BM.Damage = Damage;
        BM.Range = Range;
        BM.BulletVelocity = BulletVelocity;
        BM.Penetration = Penetration;
        Bullet.SetActive(true);
    }

    public void ShootTwinShot(GameObject Projectile, float Damage, float Range, float BulletVelocity, bool Penetration, BulletMovement.BulletTypes BulletType)
    {
        GameObject bullet = Bullets.GetBullet();
        bullet.transform.position = Firepoint1.transform.position;
        bullet.transform.rotation = Firepoint1.transform.rotation;
        BulletMovement TempBulletMovementScript = bullet.GetComponent<BulletMovement>();
        BulletInfo(bullet, TempBulletMovementScript, Damage, Range, BulletVelocity, Penetration, BulletType);

        GameObject bullet1 = Bullets.GetBullet();
        bullet1.transform.position = Firepoint2.transform.position;
        bullet1.transform.rotation = Firepoint2.transform.rotation;
        BulletMovement TempBulletMovementScript1 = bullet1.GetComponent<BulletMovement>();
        BulletInfo(bullet1, TempBulletMovementScript1, Damage, Range, BulletVelocity, Penetration, BulletType);
    }

    public void ShootShotgun(GameObject Projectile, float Damage, float Range, float BulletVelocity, bool Penetration, int AmountofPellets, float SpreadAngleMax, BulletMovement.BulletTypes BulletType)
    {
        for (int i = 0; i < AmountofPellets; i++)
        {
            Quaternion ShotgunRot = transform.rotation * Quaternion.Euler(0, 0, Random.Range(-SpreadAngleMax, SpreadAngleMax));
            GameObject bullet = Bullets.GetBullet();
            bullet.transform.position = Firepoint1.transform.position;
            bullet.transform.rotation = ShotgunRot;
            BulletMovement TempBulletMovementScript = bullet.GetComponent<BulletMovement>();
            BulletInfo(bullet, TempBulletMovementScript, Damage, Range, BulletVelocity, Penetration, BulletType);
        }

    }
    public void ShootCircular(GameObject Projectile, float Damage, float Range, float BulletVelocity, bool Penetration, int AmountofPellets, BulletMovement.BulletTypes BulletType)
    {
        float CurrentAngle = 0;
        float IntervalOfAngle = 360 / AmountofPellets;
        for (int i = 0; i < AmountofPellets; i++)
        {
            GameObject bullet = Bullets.GetBullet();
            Quaternion AngleOfShot = Quaternion.Euler(0, 0, CurrentAngle);
            CurrentAngle = CurrentAngle + IntervalOfAngle;
            bullet.transform.position = Firepoint1.transform.position;
            bullet.transform.rotation = AngleOfShot;
            BulletMovement TempBulletMovementScript = bullet.GetComponent<BulletMovement>();
            BulletInfo(bullet, TempBulletMovementScript, Damage, Range, BulletVelocity, Penetration, BulletType);

        }

    }
    public void ShootRocket(GameObject Projectile, float Damage, float Range, float BulletVelocity, bool Penetration, BulletMovement.BulletTypes BulletType)
    {
        GameObject TempBullet = Instantiate(Projectile, transform.position, transform.rotation); //Spawns and give bullet stats
        RocketMovement TempBulletMovementScript = TempBullet.GetComponent<RocketMovement>();
        TempBulletMovementScript.Damage = Damage;
        TempBulletMovementScript.Range = Range;
        TempBulletMovementScript.BulletVelocity = BulletVelocity;
        TempBulletMovementScript.Penetration = Penetration;
    }

}
