using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float BulletVelocity = 0f;
    public float Damage = 0f;
    public float Range = 0f;
    public bool Penetration = false;
    private Vector3 SpawnPos;
    private float Distence;
    public string TargetsTag = "Enemy"; //Allows the bullet to check the target
    public GameObject BloodSplater;

    public Vector2 Collpoint;
    private void Start()
    {
        SpawnPos = transform.position;
        
    
    }
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * BulletVelocity; //Bullet Velo
        Distence = Vector3.Distance(SpawnPos, transform.position); //Distence Calc
        if(Distence > Range) //Range check 
        {
            Destroy(gameObject); //Destroy the bullet
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == TargetsTag) //Checks the tag of what is hit and sees what the target for the bullet is for (EG if it is shot from the player or Enemy)
        {
            IDamageable <float> Hit = collision.GetComponent<IDamageable<float>>(); //Uses the interface system to find the interface on anything that is damageable
            Hit.Damage(Damage); //Applys the damage through the interface system

            Vector2 closestPoint = collision.ClosestPoint(Collpoint);
            BloodSplater = Resources.Load<GameObject>("Blood");
            GameObject bloodSplater = Instantiate(BloodSplater, closestPoint, Quaternion.identity);
            bloodSplater.GetComponent<BloodSplatter>().BloodSplater(closestPoint);
            Destroy(gameObject);
       
            //TODO CHECK FOR PENITION 
        }
    }
}
