using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAimer : MonoBehaviour
{
    public List<GameObject> EnemyCollisonsList = new List<GameObject>();
    public bool CanShoot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") //Enters enemy into the list to attack
        {
            EnemyCollisonsList.Add(collision.gameObject);

        }
    }
    private void OnTriggerExit2D(Collider2D collision) // Vice Versa 
    {
        for (int i = 0; i < EnemyCollisonsList.Count; i++)
        {
            if (collision.gameObject == EnemyCollisonsList[i])
            {
                //EnemyCollisonsList[i].GetComponent<EnemyHealth>().Damage(10f);
                EnemyCollisonsList.RemoveAt(i);
            }
        }
    }
    private void Update() // Enable the shooting function
    {
        if(EnemyCollisonsList.Count > 0)
        {
            CanShoot = true;
        }
        else
        {
            CanShoot = false;
        }
    }
}
