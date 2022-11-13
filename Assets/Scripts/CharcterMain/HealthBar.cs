using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image HealthBarGFX;
    public float MAXHEALTH;
    private float CurrentHealth;

    private void Start()
    {
        HealthBarGFX = GetComponent<Image>();
        CurrentHealth = MAXHEALTH;
    }
    public void UpdateHealthbar(float AmountOfDamage)
    {
        CurrentHealth = CurrentHealth - AmountOfDamage;
        HealthBarGFX.fillAmount = CurrentHealth / MAXHEALTH;
    }

}
