using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInput : MonoBehaviour
{
    public GameObject FingerIcon;
    public GameObject FingerCircle;
    private Vector3 touchPosition;
    private Vector3 StartPos;
    public float MoveX;
    public float MoveY;

    public bool ToggleMovementSystem = false;


    private void Start()
    {
        FingerCircle.SetActive(false); //Turns off UI 
        SettingMenuController.Togglemovement += TouchInput_Togglemovement;
    }

    private void TouchInput_Togglemovement()
    {
        ToggleMovementSystem = !ToggleMovementSystem;
    }

    void Update()
    {
        if (ToggleMovementSystem)//Checks for toggle 
            return;
 

        if(Input.touchCount > 0)
        {
            Touch FirstFinger = Input.GetTouch(0);
            if (EventSystem.current.currentSelectedGameObject != null && EventSystem.current.currentSelectedGameObject.tag == "Settings")
            {
                Debug.Log("UI pressed");
            }
            else
            {
                switch (FirstFinger.phase)
                {
                    case TouchPhase.Began:
                        FingerCircle.SetActive(true); //Turns on UI 
                        FingerIcon.transform.position = FirstFinger.position;//Move Circle to Correct Location
                        FingerCircle.transform.position = FirstFinger.position;
                        touchPosition = Camera.main.ScreenToWorldPoint(FirstFinger.position); //Converts fingers which comes pixel and uses camera to make world pos
                        StartPos = FirstFinger.position;
                        touchPosition.z = -1;
                        break;
                    case TouchPhase.Moved:
                        Vector3 touchPositionUpdate = Camera.main.ScreenToWorldPoint(FirstFinger.position);
                        //Controls the update of the joycon and clamps it
                        float lockX = Mathf.Clamp(FirstFinger.position.x, StartPos.x - 100f, StartPos.x + 100f);
                        float lockY = Mathf.Clamp(FirstFinger.position.y, StartPos.y - 100f, StartPos.y + 100f);
                        FingerIcon.transform.position = new Vector3(lockX, lockY, touchPosition.z);
                        //Calualations of the move speed depending on the joysitck pos // Normalises the movement to a pos or neg 1
                        MoveX = (StartPos.x - lockX) / 100f;
                        MoveY = (StartPos.y - lockY) / 100f;
                        break;
                    case TouchPhase.Ended:
                        MoveX = 0;
                        MoveY = 0;
                        FingerIcon.transform.position = touchPosition; //resets of pos when finger is off
                        FingerCircle.SetActive(false);
                        break;
                }
            }






        }
    }
}
