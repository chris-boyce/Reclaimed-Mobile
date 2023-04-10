using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusDamage : MonoBehaviour
{
    public string TargetsTag = "Enemy";
    public GameObject BloodSplater;
    public Vector2 Collpoint;
    private IEnumerator coroutine;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == TargetsTag) //Checks the tag of what is hit and sees what the target for the bullet is for (EG if it is shot from the player or Enemy)
        {
            BloodSplater = Resources.Load<GameObject>("Blood");
            IDamageable<float> Hit = collision.GetComponent<IDamageable<float>>(); //Uses the interface system to find the interface on anything that is damageable
            Hit.Damage(20); //Applys the damage through the interface system
            Vector2 closestPoint = collision.ClosestPoint(Collpoint);
            GameObject bloodSplater = Instantiate(BloodSplater, closestPoint, Quaternion.identity);
            bloodSplater.GetComponent<BloodSplatter>().BloodSplater(closestPoint);
            coroutine = ExplosionDelete();
            StartCoroutine(coroutine);

        }
    }

    private IEnumerator ExplosionDelete()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

    }
}
