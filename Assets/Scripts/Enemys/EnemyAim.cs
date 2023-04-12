using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    private BulletInstanitate EnemyBI;
    public GameObject Projectile;
    public float Damage;
    public float Range;
    public float BulletVelo;
    public float Firerate = 0.5f;
    private float Timer = 0;

    public BulletMovement.BulletTypes BulletType;

    private void Start()
    {
        EnemyBI = GetComponent<BulletInstanitate>();    

    }
    public void AimAtPlayerLocation(Transform PlayerPos)
    {
        transform.right = PlayerPos.position - transform.position; // Looks at player code 
        Timer = Timer + Time.deltaTime;
        if(Timer >= Firerate)
        {
            EnemyBI.Shoot(Projectile, Damage, Range, BulletVelo, false, BulletType); //Give values to shoot
            Timer = 0f;
        }

    }

}
