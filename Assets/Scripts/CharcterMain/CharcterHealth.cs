using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcterHealth : MonoBehaviour, IDamageable<float>
{
    public LoadScene DeathScene;
    public float MaxHealth = 100;
    public float health = 100;
    private HealthBar HealthBar;
    public AudioClip AudioDamage;
    public AudioClip CritDamage;

    private void Start()
    {
        DeathScene = GameObject.FindGameObjectWithTag("Death").GetComponent<LoadScene>();
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
        DeathScene.OnSceneLoadAdditive();
        Destroy(this.gameObject);
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
