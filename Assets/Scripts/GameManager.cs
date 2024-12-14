using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject circularBirdPrefab;
    public GameObject squareBirdPrefab;
    public Transform slingshotPosition;
    public SlingshotController slingshotController;

    private GameObject currentBird;
    private int currentBirdType = 0; // 0 = Circular, 1 = Square

    public void SpawnBird()
    {
        if (currentBird != null) Destroy(currentBird);

        if (currentBirdType == 0)
        {
            currentBird = Instantiate(circularBirdPrefab, slingshotPosition.position, Quaternion.identity);
        }
        else
        {
            currentBird = Instantiate(squareBirdPrefab, slingshotPosition.position, Quaternion.identity);
        }

        slingshotController.AssignBird(currentBird.GetComponent<BirdController>());
    }

    public void SwitchBird()
    {
        currentBirdType = (currentBirdType + 1) % 2; // Toggle between 0 and 1
        SpawnBird();
    }
}
