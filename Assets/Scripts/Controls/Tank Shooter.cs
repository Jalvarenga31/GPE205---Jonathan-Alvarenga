using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : Shooter
{
    public Transform firepointTransform;

    public override void Start()
    {
      
    }

    public override void Update()
    {

    }

    public override void Shoot(GameObject shellPrefab, float fireForce, float damageDone, float lifeSpan)
    {
        GameObject newShell = Instantiate (shellPrefab, firepointTransform.position, firepointTransform.rotation) as GameObject;

        DamageOnHit DoH = newShell.GetComponent<DamageOnHit>();

        if (DoH != null )
        {
            DoH.damageDone = damageDone;
            DoH.Owner = GetComponent<Pawn>();
        }

        Rigidbody rb = newShell.GetComponent<Rigidbody>();

        if (rb != null )
        {
            rb.AddForce(firepointTransform.forward * fireForce);
        }

        Destroy(newShell, lifeSpan);
    }
}
