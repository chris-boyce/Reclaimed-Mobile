using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAim : MonoBehaviour
{
    private BulletInstanitate EnemyBI;
    public GameObject Projectile;
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    private float Timer = 0;

    private void Start()
    {
        EnemyBI = GetComponent<BulletInstanitate>();
        FireCircle();
    }

    public void FireCircle()
    {
        Timer = Timer + Time.deltaTime;
        if (Timer >= 0.3)
        {
            EnemyBI.ShootCircular(Projectile, 5, 10, 5, false, 10, global::BulletMovement.BulletTypes.Wiggle); //Give values to shoot
            Timer = 0f;
        }
        
    }
}
