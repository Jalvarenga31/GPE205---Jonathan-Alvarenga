using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ScorePowerUp : Powerup
{
    public float scoreToAdd;
    public override void Apply(PowerupManager target)
    {
        Pawn pawn = target.GetComponent<Pawn>();

        if (pawn != null)
        {
            pawn.controller.AddToScore(scoreToAdd);
        }
    }

    public override void Remove(PowerupManager target)
    {
       
    }
}
