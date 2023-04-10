using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTimeTutorial : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0.1f;
        StartCoroutine(WaitAndPrint(2.0f));
    }

    IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 1f;
    }
}
