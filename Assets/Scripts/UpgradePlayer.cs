using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePlayer : MonoBehaviour
{
    public CharcterMovement PlayersMovement;
    public CharcterFiringScript PlayersFiringScript;
    public CircleCollider2D PlayersRangeCircle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "UpgradeBox")
        {
            collision.gameObject.GetComponent<UpgradeBox>().ToggleUI();
            Time.timeScale = 0.0f;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Time.timeScale = 1.0f;
    }

    public void UpgradeRange()
    {
        PlayersRangeCircle.radius = PlayersRangeCircle.radius + 0.1f;
    }
    public void UpgradeWeapon()
    {
        PlayersFiringScript.UpgradeWeapon();
        PlayersFiringScript.SetIcon();
    }
    public void UpgradeMovementSpeed()
    {
        PlayersMovement.MovementSpeed = PlayersMovement.MovementSpeed + 0.5f;
    }


}
