using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : Mover
{
    private Rigidbody rb;

    public override void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void Move(Vector3 direction, float speed)
    {
        Vector3 moveVector = direction.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.position + moveVector);
    }
    public override void Rotate(float rotationSpeed) 
    {
        Vector3 rotateVector = new Vector3(0.0f, 1.0f, 0.0f) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotateVector);
    }
}