using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcterHealth : MonoBehaviour, IDamageable<float>
{
    public float health = 100;
    private HealthBar HealthBar;

    private void Start()
    {
        HealthBar = GameObject.FindObjectOfType<HealthBar>();
        HealthBar.MAXHEALTH = health;
    }

    private void Update()
    {
        if(health < 0)
        {
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        //gameObject.SetActive(false);
        //Todo Activate UI //Create Respawn system
    }

    public void Damage(float DamageTaken)
    {
        health -= DamageTaken;
        Debug.Log("Player Hit");
        HealthBar.UpdateHealthbar(DamageTaken);
        //Screen Shake 
        //Flash Red
        //Audio
        //Virabation 
    }
}
