using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{
    public enum AIState { Gaurd, Chase, Attack, Patrol };
    public AIState currentState;
    private float lastStateChangeTime;
    public GameObject target;
    public Transform[] waypoints;
    public float waypointStopDistance;
    private int currentWaypoint = 0;
    public float hearingDistance;
    public float fieldOfView;
    public float fleeDistance;

    public override void Start()
    {  
        //ChangeState(AIState.Chase);
        //ChangeState(AIState.Patrol);
        //ChangeState(AIState.Gaurd);
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        ProcessInputs();
        base.Update();
    }

    public override void ProcessInputs()
    {
        Debug.Log("Making Decisions");
        switch (currentState)
        {
            case AIState.Gaurd:
                DoGuardState();
                IsCanSee(target);
                IsCanHear(target);
                if (IsDistanceLessThan(target, 7))
                {
                    ChangeState(AIState.Chase);
                }
                break;

            case AIState.Chase:
                if (IsHasTarget())
                { 
                    DoChaseState();
                }
                else
                {
                    TargetPlayerOne();
                }
                       
                if (IsDistanceLessThan(target, 5))
                {
                    ChangeState(AIState.Attack);
                }
                if (!IsDistanceLessThan(target, 7))
                {
                    ChangeState(AIState.Gaurd);
                }
                break;

            case AIState.Attack:
                {
                    DoAttackState();
                    if (!IsDistanceLessThan(target, 5))
                    {
                        ChangeState(AIState.Chase);
                    }
                }
                break;

            case AIState.Patrol:
                {
                    DoPatrolState();
                    
                    if (IsDistanceLessThan(target, 7))
                    {
                        ChangeState(AIState.Chase);
                    }

                }
                break;
        }
    }
    

    protected void DoPatrolState()
    {
        if (waypoints.Length > currentWaypoint)
        {
            Seek(waypoints[currentWaypoint]);
            if (Vector3.Distance(pawn.transform.position, waypoints[currentWaypoint].position) < waypointStopDistance)
            {
                currentWaypoint++;
            }
        }
        else
        {
            RestartPatrol();
        }

    }

    protected void RestartPatrol()
    {
        currentWaypoint = 0;
    }

    protected void DoGuardState()
    {
        Debug.Log("Guarding");
    }

    protected void DoChaseState()
    {
        Debug.Log("Chasing");
        Seek(target);
    }

    public void Seek (GameObject target)
    {
        pawn.RotateTowards(target.transform.position);
        pawn.MoveForward();
    }

    public void Seek (Transform targetTransform)
    {
        Seek(targetTransform.gameObject);
    }

    public void DoAttackState()
    {
        Seek(target);
        Shoot();
        Debug.Log("Attacking!");
    }

    public void Shoot()
    {
        pawn.Shoot();
    }

    protected bool IsDistanceLessThan (GameObject target, float distance)
    {
        if (Vector3.Distance (pawn.transform.position, target.transform.position) < distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual void ChangeState(AIState newState)
    {
        currentState = newState;
        lastStateChangeTime = Time.time;
    }

    public void TargetPlayerOne()
    {
        if(GameManager.instance != null)
        {
            if (GameManager.instance.players.Count > 0)
            {
                target = GameManager.instance.players[0].pawn.gameObject;
            }
        }
    }

    protected bool IsHasTarget()
    {
        return (target != null);
    }

    protected bool IsCanHear(GameObject target)
    {
        NoiseMaker noiseMaker = target.GetComponent<NoiseMaker>();
        if (noiseMaker == null)
        {
            return false;
        }
        if (noiseMaker.volumeDistance <= 0)
        {
            return false;
        }
        float totalDistance = noiseMaker.volumeDistance + hearingDistance;

        if (Vector3.Distance(pawn.transform.position, target.transform.position) <= totalDistance)
        {
            Debug.Log("I can hear!");
            return true;
        }
        else 
        { 
            return false; 
        }
    }

    protected bool IsCanSee(GameObject target)
    {
        Vector3 agentToTargetVector = target.transform.position - pawn.transform.position;
        float angleToTarget = Vector3.Angle(agentToTargetVector, pawn.transform.forward);
        Debug.Log(angleToTarget);
        if(angleToTarget < fieldOfView)
        {
            Debug.Log("In Field of View!");
            return true;
        }
        else
        {
            return false;
        }
    }

}
