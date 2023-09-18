using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPositions;
    public GameObject enemy;

    public int amountPerWave;
    public float timeBetweenWaves;

    private float timer = 0;
    private void Update()
    {
        if (timer > timeBetweenWaves)
        {
            for (int i = 0; i < amountPerWave; i++)
                Instantiate(enemy, spawnPositions[Random.Range(0, spawnPositions.Length)].position, Quaternion.identity);

            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
