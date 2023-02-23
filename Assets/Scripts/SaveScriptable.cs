using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SaveSO", menuName = "SaveSO")]
public class SaveScriptable : ScriptableObject
{
    [Header("Save Data")]
    public int Saveint;
    public int SavedCurrentLevel;
    public float SavedHealth;
    public float SavedRange;
    public GunCard SavedPrimaryWeapon;
    public GunCard SavedSecondaryWeapon;

}
