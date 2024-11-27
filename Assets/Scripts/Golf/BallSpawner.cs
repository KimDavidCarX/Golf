using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [Header("Settings")]
    public GameObject rockPrefab;
    public Transform spawnPoint;
    public Vector2 spawnRange = new Vector2(1f, 5f);
    public float rangeReduction = 0.2f;
    public float minimumSpawnTime = 0.5f;

    private float nextSpawnTime;

    private void Start()
    {
        nextSpawnTime = Random.Range(spawnRange.x, spawnRange.y);
        StartCoroutine(SpawnRocks());
    }

    private IEnumerator SpawnRocks()
    {
        while (true)
        {
            yield return new WaitForSeconds(nextSpawnTime);

            SpawnRock();

            spawnRange.y = Mathf.Max(spawnRange.y - rangeReduction, minimumSpawnTime);

            nextSpawnTime = Random.Range(spawnRange.x, spawnRange.y);
        }
    }

    private void SpawnRock()
    {
        Instantiate(rockPrefab, spawnPoint.position, Quaternion.identity);
    }
}
