using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SpeedBoostPickup : Powerup
{
    public float SpeedBoost;
    
    public override void Apply(PowerupManager target)
    {
        Pawn targetSpeed = target.GetComponent<Pawn>();
        if (targetSpeed != null)
        {
            targetSpeed.Speeds(SpeedBoost, target.GetComponent<Pawn>());
        }
    }

    public override void Remove(PowerupManager target)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
