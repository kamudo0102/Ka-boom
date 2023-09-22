using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject explodingEnemy;

    private bool[] usedPositions;

    private int amountPerWave;
    private float timeBetweenWaves;

    public int enemiesKilled = 0;
    private int enemiesSpawned = 0;

    private float timer = 0;

    private void Start()
    {
        Instance = this;

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
        timeBetweenWaves = 5 - enemiesKilled * 0.01f;
        amountPerWave = 2 + Mathf.FloorToInt(enemiesKilled / 20);

        if (amountPerWave > spawnPositions.Length)
            amountPerWave = spawnPositions.Length;
        if (timeBetweenWaves < 0.5f)
            timeBetweenWaves = 0.5f;

        for (int i = 0; i < amountPerWave; i++)
        {
            int chosenSpawnPoint = Random.Range(0, spawnPositions.Length);

            while (usedPositions[chosenSpawnPoint])
                chosenSpawnPoint = Random.Range(0, spawnPositions.Length);

            if (enemiesSpawned - enemiesKilled < 50)
            {
                if (enemiesSpawned > 0 && enemiesSpawned % 5 == 0)
                    Instantiate(explodingEnemy, spawnPositions[chosenSpawnPoint].position, Quaternion.identity);
                else
                    Instantiate(enemy, spawnPositions[chosenSpawnPoint].position, Quaternion.identity);


                usedPositions[chosenSpawnPoint] = true;
                enemiesSpawned++;
            }
        }

        for (int i = 0; i < usedPositions.Length; i++)
            usedPositions[i] = false;
    }
}
