using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcterMovement : MonoBehaviour
{
    public TouchInput JoyconInput;
    public float MovementSpeed = 5f;
    Rigidbody2D RB;
    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 Movement = new Vector3(-JoyconInput.MoveX, -JoyconInput.MoveY, 0); 
        RB.MovePosition(transform.position + Movement * Time.deltaTime * MovementSpeed);
    }

}
