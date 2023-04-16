using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public enum BulletTypes { Default, Wiggle };
    public BulletTypes BulletType;
    public float BulletVelocity = 0f;
    public float Damage = 0f;
    public float Range = 0f;
    public bool Penetration = false;
    private Vector2 SpawnPos;
    private float Distence;
    public string TargetsTag = "Enemy"; //Allows the bullet to check the target
    public GameObject BloodSplater;

    public Vector2 Collpoint;

    public float speed = 5f;
    public Vector2 startPosition;
    public Vector2 direction;
    public float time;
    public Vector2 crossDirection;
    public float frequency;
    public float amplitude;

    public void OnEnable()
    {
        SpawnPos = transform.position;
        time = 0.0f;
        direction = transform.right;
        crossDirection = new Vector2(direction.y, -direction.x); // A quick right angle for 2D
        startPosition = transform.position;
    }
    void Update()
    {
        switch (BulletType)
        {
            case BulletTypes.Default:
                transform.position += transform.right * Time.deltaTime * BulletVelocity; //Bullet Velo
                break;
            case BulletTypes.Wiggle:
                transform.position = startPosition + (direction * speed * time) + (crossDirection * Mathf.Sin(time * frequency) * amplitude);
                time += Time.deltaTime;
                break;
        }
        
        

        Distence = Vector3.Distance(SpawnPos, transform.position); //Distence Calc
        if(Distence > Range) //Range check 
        {
            gameObject.SetActive(false); //Destroy the bullet
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == TargetsTag) //Checks the tag of what is hit and sees what the target for the bullet is for (EG if it is shot from the player or Enemy)
        {
            IDamageable <float> Hit = collision.GetComponent<IDamageable<float>>(); //Uses the interface system to find the interface on anything that is damageable
            Hit.Damage(Damage); //Applys the damage through the interface system
            Vector2 closestPoint = collision.ClosestPoint(Collpoint);
            if (PlayerPrefs.GetInt("BloodEnable") != 0)
            {
                BloodSplater = Resources.Load<GameObject>("Blood");
                GameObject bloodSplater = Instantiate(BloodSplater, closestPoint, Quaternion.identity);
                bloodSplater.GetComponent<BloodSplatter>().BloodSplater(closestPoint);
            }
            gameObject.SetActive(false);

        }
    }
}
