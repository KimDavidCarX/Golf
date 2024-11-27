using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [Header("Settings")]
    public GameObject rockPrefab; // Префаб камня
    public Transform spawnPoint; // Точка спавна (над персонажем)
    public Vector2 spawnRange = new Vector2(1f, 5f); // Диапазон появления в секундах (N)
    public float rangeReduction = 0.2f; // Уменьшение верхней границы диапазона на каждый спавн (N ms)
    public float minimumSpawnTime = 0.5f; // Минимальное значение верхней границы

    private float nextSpawnTime; // Время до следующего спавна

    private void Start()
    {
        // Устанавливаем первое время спавна
        nextSpawnTime = Random.Range(spawnRange.x, spawnRange.y);
        StartCoroutine(SpawnRocks());
    }

    private IEnumerator SpawnRocks()
    {
        while (true)
        {
            yield return new WaitForSeconds(nextSpawnTime);

            // Спавним камень
            SpawnRock();

            // Уменьшаем верхнюю границу диапазона
            spawnRange.y = Mathf.Max(spawnRange.y - rangeReduction, minimumSpawnTime);

            // Устанавливаем новое время спавна
            nextSpawnTime = Random.Range(spawnRange.x, spawnRange.y);
        }
    }

    private void SpawnRock()
    {
        // Создаем камень в позиции спавна
        Instantiate(rockPrefab, spawnPoint.position, Quaternion.identity);
    }
}
