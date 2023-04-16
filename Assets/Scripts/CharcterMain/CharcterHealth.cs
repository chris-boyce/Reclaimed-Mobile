using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcterHealth : MonoBehaviour, IDamageable<float>
{
    public float MaxHealth = 100;
    public float health = 100;
    private HealthBar HealthBar;
    public AudioClip AudioDamage;
    public AudioClip CritDamage;

    private void Start()
    {
        health = MaxHealth;
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
        if (PlayerPrefs.GetInt("HapticEnable") != 0)
        {
            Handheld.Vibrate();
        }
        health -= DamageTaken;
        Debug.Log("Player Hit");
        HealthBar.UpdateHealthbar(DamageTaken);//UI for Health
        if (health <= 20)
        {
            SoundController.PlaySound(CritDamage);
        }
        //Screen Shake 
        SoundController.PlaySound(AudioDamage);
    }
}
