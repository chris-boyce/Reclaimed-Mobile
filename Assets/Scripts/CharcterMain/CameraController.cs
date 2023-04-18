using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform Player;
    public Vector3 OffSet;
    public Transform BoundingBox;

    float CamX;
    float CamY;

    private Camera cam;
    int layerMask;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        BoundingBox = GameObject.Find("BoundingBox").GetComponent<Transform>();
        cam = GetComponent<Camera>();
        layerMask = (LayerMask.GetMask("Obstacle"));
    }
    private void Update()
    {
        RaycastHit2D hitright = Physics2D.Raycast(BoundingBox.position, Vector2.right, 5.5f, layerMask);
        RaycastHit2D hitup = Physics2D.Raycast(BoundingBox.position, Vector2.up, 14f, layerMask);
        RaycastHit2D hitleft = Physics2D.Raycast(BoundingBox.position, Vector2.left, 5.5f, layerMask);
        RaycastHit2D hitdown = Physics2D.Raycast(BoundingBox.position, Vector2.down, 14f, layerMask);


        if (!RaycastCheck(hitleft) && !RaycastCheck(hitright))
        {
            CamX = Player.position.x;
        }
        else
        {
            CamX = transform.position.x;
        }
        if (!RaycastCheck(hitdown) && !RaycastCheck(hitup))
        {
            CamY = Player.position.y;
        }
        else
        {
            CamY = transform.position.y;
        }
        transform.position = new Vector3(CamX, CamY, OffSet.z);


    }
    bool RaycastCheck(RaycastHit2D hit)
    {
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Wall")
            {
                Debug.DrawRay(BoundingBox.position, hit.point, Color.blue);
                return true;
            }
            return false;
        }
        else
        {

            Debug.DrawRay(BoundingBox.position, hit.point, Color.red);
            return false;
        }
      
    }
    private void FixedUpdate()
    {
        

    }

}
