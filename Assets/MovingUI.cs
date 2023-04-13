using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingUI : MonoBehaviour
{
    public float Amp;
    public float Feq;
    public bool Clamped;
    void Update()
    {
        if (Clamped)
        {
            float x = Mathf.Sin(Time.time / Feq) + Amp;
            float xS = Mathf.Clamp(x, 1f, 1.5f);
            float y = Mathf.Sin(Time.time / Feq) + Amp;
            float yS = Mathf.Clamp(y, 1f, 1.5f);
            float z = Mathf.Sin(Time.time / Feq) + Amp;
            float zS = Mathf.Clamp(z, 1f, 1.5f);
            Vector3 vec = new Vector3(xS, yS, zS);

            transform.localScale = vec;
        }
        else
        {
            Vector3 vec = new Vector3(Mathf.Sin(Time.time * Feq) + Amp, Mathf.Sin(Time.time * Feq) + Amp, Mathf.Sin(Time.time * Feq) / Amp);

            transform.localScale = vec;
        }
       

    }
    
}
