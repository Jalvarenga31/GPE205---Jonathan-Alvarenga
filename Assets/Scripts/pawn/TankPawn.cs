using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    private float nextEventTime;
    private float timerDelay;

    public override void Start()
    {
        float secondsPerShot;
        if(fireRate <= 0)
        {
            secondsPerShot = Mathf.Infinity;
        }
        else
        {
            secondsPerShot = 1 / fireRate;
        }
        timerDelay = secondsPerShot;
        nextEventTime = Time.time + timerDelay;
        base.Start();
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    public override void MoveForward()
    {
        mover.Move(transform.forward, moveSpeed);
    }

    public override void MoveBackward()
    {
        mover.Move(transform.forward, -moveSpeed);
    }

    public override void RotateClockwise()
    {
        mover.Rotate(turnSpeed);
    }

    public override void RotateCounterClockwise()
    {
        mover.Rotate(-turnSpeed);
    }

    public override void Shoot()
    {
        if(Time.time >= nextEventTime)
        {
            shooter.Shoot(shellPrefab, fireForce, damageDone, shellLifespan);
            nextEventTime = Time.time + timerDelay;
        }
        
    }

   public override void RotateTowards(Vector3 targetPosition)
    {
        Vector3 vectorToTarget = targetPosition - transform.position;       
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);       
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }
    
    public override void MakeNoise()
    {
        if (noiseMaker != null)
        {
            noiseMaker.volumeDistance = noiseMakerVolume;
        }
    }

    public override void StopNoise()
    {
        if(noiseMaker != null)
        {
            noiseMaker.volumeDistance = 0;  
        }
    }

    public override void Die(Pawn source)
    {
        Destroy(gameObject, 2);
        Debug.Log(gameObject.name + " was killed by: " + source.name);   
    }

}