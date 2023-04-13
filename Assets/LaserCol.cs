using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCol : MonoBehaviour
{
    public float Damage;
    public string TargetsTag = "Player";
    private void OnTriggerEnter2D(Collider2D collision)
    {

        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == TargetsTag) //Checks the tag of what is hit and sees what the target for the bullet is for (EG if it is shot from the player or Enemy)
        {
            IDamageable<float> Hit = other.GetComponent<IDamageable<float>>(); //Uses the interface system to find the interface on anything that is damageable
            Hit.Damage(Damage); //Applys the damage through the interface system
            Destroy(gameObject);

            //TODO CHECK FOR PENITION 
        }
    }
}
