using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplatter : MonoBehaviour
{
    public Animator BloodAnim;
    // Start is called before the first frame update

    private void Start()
    {
        
    }
    public void BloodSplater(Vector3 SpawnPos)
    {
        int randNum =  Random.Range(0, 3);
        if (randNum == 0) 
        {
            BloodAnim.Play("Blood1");
        }
        else if (randNum == 1) 
        {
            BloodAnim.Play("Blood2");
        }
        else if (randNum == 1) 
        {
            BloodAnim.Play("Blood3");
        }
        else
        {
            BloodAnim.Play("Blood4");
        }
        transform.position = SpawnPos;
        StartCoroutine(Fade(3));
    }

    IEnumerator Fade(float duration)
    {
        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            Color newColor = rend.material.color;
            newColor.a = newColor.a - 0.001f;
            rend.material.color = newColor;
            yield return null;

        }

        yield return new WaitForSeconds(duration);
        Destroy(this.gameObject);

    }
}
