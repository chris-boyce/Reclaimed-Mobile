using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SavePlayerStats : MonoBehaviour
{
    public float SavedMovementSpeed;
    public float SavedHealth;
    public float SavedRange;
    public GunCard SavedPrimaryWeapon;
    public GunCard SavedSecondaryWeapon;

    public GameObject Player;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
       
    }
    private void OnLevelWasLoaded(int level)
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            Player = GameObject.FindWithTag("Player");

        }

    }

    public void SaveStats()
    {
        SavedMovementSpeed = Player.GetComponent<CharcterMovement>().MovementSpeed;
        SavedHealth = Player.GetComponent<CharcterHealth>().MaxHealth;
        SavedRange = Player.GetComponentInChildren<CircleCollider2D>().radius;
        SavedPrimaryWeapon = Player.GetComponentInChildren<CharcterFiringScript>().GunList[0];
        SavedSecondaryWeapon = Player.GetComponentInChildren<CharcterFiringScript>().GunList[1];
    }
}
