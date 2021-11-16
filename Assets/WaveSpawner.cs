using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnerPosition;

    private float timeBetweenSpawn = 4f;
    private float countDown;
    private int waveIndex = 0;

    private void Update()
    {
        if (countDown <= 0)
        {
            countDown = timeBetweenSpawn;
            StartCoroutine(spawnWave());
        }
        countDown -= Time.deltaTime;
    }

    IEnumerator spawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        { 
            spawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawnerPosition.position, spawnerPosition.rotation);
    }
}
