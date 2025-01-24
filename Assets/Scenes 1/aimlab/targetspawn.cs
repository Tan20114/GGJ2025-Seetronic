using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetspawn : MonoBehaviour
    {
    public GameObject targetPrefab;
    public float spawnInterval = 1.5f;
    public Vector2 spawnRange = new Vector2(3f, 3f);

    private void Start()
    {
        InvokeRepeating(nameof(SpawnTarget), 0f, spawnInterval);
    }

    private void SpawnTarget()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnRange.x, spawnRange.x),
            Random.Range(-spawnRange.y, spawnRange.y),
            0
        );

        Instantiate(targetPrefab, randomPosition, Quaternion.identity);
    }
}

