using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private GameObject enemy;

    private bool[] usedPositions;

    public int amountPerWave;
    public float timeBetweenWaves;

    private float timer = 0;

    private void Start()
    {
        usedPositions = new bool[spawnPositions.Length];

        for (int i = 0; i < usedPositions.Length; i++)
            usedPositions[i] = false;

        SpawnEnemies();
    }

    private void Update()
    {
        if (timer > timeBetweenWaves)
        {
            SpawnEnemies();

            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private void SpawnEnemies()
    {
        if (amountPerWave > spawnPositions.Length)
            amountPerWave = spawnPositions.Length;
        if (timeBetweenWaves < 0.5f)
            timeBetweenWaves = 0.5f;

        for (int i = 0; i < amountPerWave; i++)
        {
            int chosenSpawnPoint = Random.Range(0, spawnPositions.Length);

            while (usedPositions[chosenSpawnPoint])
                chosenSpawnPoint = Random.Range(0, spawnPositions.Length);

            Instantiate(enemy, spawnPositions[chosenSpawnPoint].position, Quaternion.identity);

            usedPositions[chosenSpawnPoint] = true;
        }

        for (int i = 0; i < usedPositions.Length; i++)
            usedPositions[i] = false;
    }
}
