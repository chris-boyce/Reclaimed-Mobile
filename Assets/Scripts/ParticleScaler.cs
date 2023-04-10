using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScaler : MonoBehaviour
{
    ParticleSystem _ps;
    public float sizeModifier = 1.0f;
    void Awake()
    {
        _ps = GetComponent<ParticleSystem>();
        //For each property you want to scale, just multiply it by the size modifier.
        _ps.startSize *= sizeModifier;
    }
}
