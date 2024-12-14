using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 acceleration = new Vector3(0, -9.8f, 0);
    public float mass;

    private void Update()
    {
        ApplyPhysics();
    }

    public void Launch(Vector3 force)
    {
        velocity = force / mass;
    }

    private void ApplyPhysics()
    {
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }

    public Vector3 GetVelocity()
    {
        return velocity;
    }
}
