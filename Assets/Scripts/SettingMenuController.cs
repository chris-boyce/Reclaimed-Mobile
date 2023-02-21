using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenuController : MonoBehaviour
{
    [SerializeField]private LoadScene LoadSceneControl;
    public bool MenuActive = false;


    public delegate void ToggleMovement();
    public static event ToggleMovement Togglemovement;

    private void Start()
    {
        LoadSceneControl = GetComponent<LoadScene>();
    }

    public void SettingsUp()
    {
        MenuActive = !MenuActive;
        if(MenuActive)
        {
            StartCoroutine(Wait(0.5f));
            LoadSceneControl.OnSceneLoadAdditive();
            Togglemovement();
            
        }
        else
        {
            Time.timeScale = 1.0f;
            LoadSceneControl.OnSceneDeloadAdditive();
            Togglemovement();
        }
    }
    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Time.timeScale = 0.0f;
    }

}
