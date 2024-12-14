using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigController : MonoBehaviour
{
    public float toughness = 5.0f;

    public void TakeHit(float impactForce)
    {
        if (impactForce > toughness)
        {
            Destroy(gameObject);
        }
    }
}
