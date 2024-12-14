using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 acceleration = new Vector3(0, -9.8f, 0);
    public float toughness;

    public void ApplyForce(Vector3 force)
    {
        velocity += force;
    }

    private void Update()
    {
        ApplyPhysics();
        CheckCollisions();
    }

    private void ApplyPhysics()
    {
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

    private void CheckCollisions()
    {
        foreach (GameObject bird in GameObject.FindGameObjectsWithTag("Bird"))
        {
            if (IsCollidingWithBird(bird))
            {
                HandleCollisionWithBird(bird);
            }
        }
    }

    private bool IsCollidingWithBird(GameObject bird)
    {
        Vector3 birdPos = bird.transform.position;
        Vector3 blockPos = transform.position;
        Vector3 blockScale = transform.localScale;

        bool collisionX = Mathf.Abs(birdPos.x - blockPos.x) < (blockScale.x / 2);
        bool collisionY = Mathf.Abs(birdPos.y - blockPos.y) < (blockScale.y / 2);

        return collisionX && collisionY;
    }

    private void HandleCollisionWithBird(GameObject bird)
    {
        Vector3 birdVelocity = bird.GetComponent<BirdController>().GetVelocity();
        float impactForce = birdVelocity.magnitude;

        if (impactForce > toughness)
        {
            Destroy(gameObject);
        }
    }
}
