using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;
    public Wave[] waves;
    public Transform spawnerPosition;
    public Text countDownText;
    private GameManager gameManager;
    private float timeBetweenSpawn = 5f;
    private float countDown;
    private int waveIndex = 0;
    void Start()
    {
        gameManager = GameManager.GetInstance();
    }

    private void Update()
    {
        if (countDown <= 0)
        {
            countDown = timeBetweenSpawn;
            StartCoroutine(spawnWave());
            return;
        }
        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0, Mathf.Infinity);
        countDownText.text = string.Format("{0:00.00}", countDown);
    }

    IEnumerator spawnWave()
    {
        PlayerStat playerStat = PlayerStat.GetInstance();
        playerStat.SetRounds(waveIndex);

        if (waveIndex < waves.Length)
        {
            Wave wave = waves[waveIndex];
            waveIndex++;
            for (int i = 0; i < wave.count; i++)
            {
                spawnEnemy(wave.enemy);
                yield return new WaitForSeconds(1f / wave.rate);
            }
        }
        else if (enemiesAlive == 0)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }



    }

    public void spawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnerPosition.position, spawnerPosition.rotation);
        enemiesAlive += 1;
    }
    public float GetCountDown()
    {
        return countDown;
    }
}
