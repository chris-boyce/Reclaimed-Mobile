using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Animator Anim;
    public BoxCollider2D DamageBox;

    void Start()
    {
        DamageBox.enabled = false;
    }

    public void IsHalfWay()
    {
        Debug.Log("Firing the Lasers");
        DamageBox.enabled = true;
    }

    public void IsFinished()
    {
        Debug.Log("Laser Stopped");
        DamageBox.enabled = false;
        gameObject.SetActive(false);
    }

}
