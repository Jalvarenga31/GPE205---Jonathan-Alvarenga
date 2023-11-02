using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class HealthIncreasePickup : Powerup
{
    public float healthToIncrease;
    public float healthToAdd;

    public override void Apply(PowerupManager target)
    {
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.HealthUp(healthToIncrease, target.GetComponent<Pawn>());
            targetHealth.Heal(healthToAdd, target.GetComponent<Pawn>());
        }


    }

    public override void Remove(PowerupManager target)
    {
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(healthToIncrease, target.GetComponent<Pawn>());
            targetHealth.TakeDamage(healthToAdd, target.GetComponent<Pawn>());
        }
    }
}
