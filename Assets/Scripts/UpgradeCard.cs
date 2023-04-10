using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Upgrade Weapons In Completed
//Fix Other Upgrades

public enum UpgradeEnum {NULL, Range, MovementSpeed, UpgradeWeapon, SplitShot }

[CreateAssetMenu(fileName = "UpgradeCard", menuName = "Upgrades")]
public class UpgradeCard : ScriptableObject
{
    public string UpgradeName;
    public string UpgradeDescription;
    public UpgradeEnum UpgradeCat;
    public float PercentageChange;
    public Sprite UpgradeArt;
}
