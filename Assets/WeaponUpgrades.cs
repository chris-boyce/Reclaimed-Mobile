using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrades : MonoBehaviour
{
    public CharcterFiringScript CharcterFiringScript;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WeaponBox")
        {
            Debug.Log("Running Please");
            collision.gameObject.GetComponent<WeaponUnlockBox>().ToggleUI();
            Time.timeScale = 0.0f;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Time.timeScale = 1.0f;
    }
    public void ChangePrimary(WeaponTypes WeaponUnlock)
    {
        CharcterFiringScript.Primary = WeaponUnlock;
        Debug.Log("Set Firing SCript");
        Debug.Log(WeaponUnlock.ToString());
    }
    public void ChangeSecondary(WeaponTypes WeaponUnlock)
    {
        CharcterFiringScript.Secondary = WeaponUnlock;
        Debug.Log("Set Firing SCript");
        Debug.Log(WeaponUnlock.ToString());
    }
}
