using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Pawn : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    public float fireRate;
    public GameObject shellPrefab;
    public float fireForce;
    public float damageDone;
    public float shellLifespan;
    public Mover mover;
    public Shooter shooter;
    public NoiseMaker noiseMaker;
    public float noiseMakerVolume;
    public Controller controller;
    public float StartingLives;
    public float CurrentLives;
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        CurrentLives = StartingLives;
        mover = GetComponent<Mover>();
        shooter = GetComponent<Shooter>();
        noiseMaker = GetComponent<NoiseMaker>();
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public void Speeds(float amount, Pawn source)
    {
        moveSpeed += amount;
    }

    public abstract void MoveForward();

    public abstract void MoveBackward();

    public abstract void RotateClockwise();

    public abstract void RotateCounterClockwise();

    public abstract void Shoot();

    public abstract void RotateTowards(Vector3 targetPosition);

    public abstract void MakeNoise();

    public abstract void StopNoise();

    public abstract void Die(Pawn source);
}