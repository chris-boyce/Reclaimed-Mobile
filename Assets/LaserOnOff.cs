using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserOnOff : MonoBehaviour
{
    private float nextActionTime = 0.0f;
    public float period = 7f;
    public GameObject Laser;

    void Start()
    {
        period = Random.Range(7.0f, 13.0f);
        Laser.SetActive(false);
    }
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            Laser.SetActive(true);
        }
    }
}
