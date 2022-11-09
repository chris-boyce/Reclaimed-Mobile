using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform Player;
    public Vector3 OffSet;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }
    private void Update()
    {
        transform.position = new Vector3(Player.position.x + OffSet.x, Player.position.y + OffSet.y, OffSet.z);
    }

}
