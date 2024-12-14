using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotController : MonoBehaviour
{
    public Transform slingshotCenter;
    public float maxPullDistance = 3.0f;
    private BirdController currentBird;

    private void Update()
    {
        if (currentBird != null && Input.GetMouseButton(0))
        {
            DragBird();
        }

        if (Input.GetMouseButtonUp(0) && currentBird != null)
        {
            LaunchBird();
        }
    }

    public void AssignBird(BirdController bird)
    {
        currentBird = bird;
    }

    private void DragBird()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 direction = mousePosition - slingshotCenter.position;
        float distance = Mathf.Min(direction.magnitude, maxPullDistance);

        Vector3 pullPosition = slingshotCenter.position + direction.normalized * distance;
        currentBird.transform.position = pullPosition;
    }

    private void LaunchBird()
    {
        Vector3 launchForce = (slingshotCenter.position - currentBird.transform.position) * 5f;
        currentBird.Launch(launchForce);
        currentBird = null;
    }
}
