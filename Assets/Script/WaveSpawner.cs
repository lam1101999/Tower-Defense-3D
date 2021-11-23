using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnerPosition;
    public Text countDownText;

    private float timeBetweenSpawn = 5f;
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
        countDownText.text = Mathf.Floor(countDown).ToString();
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
    public float GetCountDown(){
        return countDown;
    }
}
