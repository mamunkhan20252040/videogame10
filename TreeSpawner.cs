using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public GameObject treePrefab; // Assign your tree Prefab here in the Inspector
    public int numberOfTrees = 100;
    public float spawnRadius = 50f; // Radius of the area to spawn trees
    void Start()
    {
        for (int i = 0; i < numberOfTrees; i++)
        {
            // Generate a random position within the defined radius
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnRadius, spawnRadius),
                100, // Adjust Y position based on your scene setup (e.g., your ground height)
                Random.Range(-spawnRadius, spawnRadius)
            );
            // Instantiate the tree Prefab at the random position with a random rotation
            Instantiate(treePrefab, randomPosition, Quaternion.Euler(0, Random.Range(0, 360), 0));
        }
    }
}
