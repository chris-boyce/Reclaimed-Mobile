using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum UpgradeEnum {NULL, Range, Damage, MovementSpeed, Firerate }

[CreateAssetMenu(fileName = "UpgradeCard", menuName = "Upgrades")]
public class UpgradeCard : ScriptableObject
{
    public string UpgradeName;
    public string UpgradeDescription;
    public UpgradeEnum UpgradeCat;
    public float PercentageChange;
    public Sprite UpgradeArt;
}
