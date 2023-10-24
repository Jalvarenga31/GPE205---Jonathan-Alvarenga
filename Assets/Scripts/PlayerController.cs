using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
    public KeyCode shootKey;

    public override void Start()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.players != null)
            {
                GameManager.instance.players.Add(this);
            }
        }
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
        if (Input.GetKey(moveForwardKey))
        {
            pawn.MoveForward();
            pawn.MakeNoise();
        }

        if (Input.GetKey(moveBackwardKey))
        {
            pawn.MoveBackward();
            pawn.MakeNoise();
        }

        if (Input.GetKey(rotateClockwiseKey))
        {
            pawn.RotateClockwise();
            pawn.MakeNoise();
        }

        if (Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
            pawn.MakeNoise();
        }

        if (Input.GetKeyDown(shootKey))
        {
            pawn.Shoot();
            pawn.MakeNoise();
        }

        if (!Input.GetKey(moveForwardKey) && !Input.GetKey(moveBackwardKey) && !Input.GetKey(rotateClockwiseKey) && !Input.GetKey(rotateCounterClockwiseKey) && !Input.GetKeyDown(shootKey))
        {
            pawn.StopNoise();
        }

    }

    public void OnDestroy()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.players.Remove(this);
        }
    }
}