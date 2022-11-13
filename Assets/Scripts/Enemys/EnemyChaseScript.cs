using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyChaseScript : MonoBehaviour
{
    public Transform Target;
    public float Speed;

    public float NextWaypointDistence = 3f;
    public float EnemyRange = 1f;

    Path CurrentPath;
    int CurrentWaypoint = 0;
    bool ReachEndOfPath = false;

    private EnemyAim EnemyAim;

    Seeker Seeker;
    Rigidbody2D RB;

    void Start()
    {
        Seeker = GetComponent<Seeker>();
        RB = GetComponent<Rigidbody2D>();
        Target = GameObject.FindWithTag("Player").gameObject.transform;
        InvokeRepeating("UpdatePath", 1f, 0.5f);
        EnemyAim = GetComponent<EnemyAim>();

    }
    void UpdatePath()
    {
        if(Seeker.IsDone())
        {
            Seeker.StartPath(RB.position, Target.position, OnPathComplete);
        }
        
    }

    void OnPathComplete(Path P)
    {
        if(!P.error)
        {
            CurrentPath = P;
            CurrentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        if (CurrentPath == null)
            return;
        if (CurrentWaypoint >= CurrentPath.vectorPath.Count)
        {
            ReachEndOfPath = true;
            return;
        }
        else
        {
            ReachEndOfPath = false;
        }
        Vector2 Direction = ((Vector2)CurrentPath.vectorPath[CurrentWaypoint] - RB.position).normalized;
        Vector2 Force = Direction * Speed * Time.deltaTime;
        RB.AddForce(Force);
        float Distence = Vector2.Distance(RB.position, CurrentPath.vectorPath[CurrentWaypoint]);
        if(Distence < NextWaypointDistence)
        {
            CurrentWaypoint++;
        }
        float DistenceFromTarget = Vector2.Distance(RB.position, Target.position);
        if (DistenceFromTarget < EnemyRange)
        {
            Seeker.StartPath(RB.position, RB.position, OnPathComplete);
            EnemyAim.AimAtPlayerLocation(Target);
            //CanAttack
        }

    }
}
