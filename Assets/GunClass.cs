using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class GunClass : MonoBehaviour 
{
    public float Firerate;
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
            BI.Shoot(Bullet, Damage, Range, BulletVelocity, Penetration);
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
}


