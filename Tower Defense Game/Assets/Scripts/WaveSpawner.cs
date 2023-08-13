using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves;
    private float countdown = 2f;
    private int waveNumber = 2;
    public TextMeshProUGUI waveCountdownText;


    void Update()
    {
        if (countdown <= 0f )
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0 , Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown );
    }
    IEnumerator SpawnWave()
    {
        for ( int i = 0; i < waveNumber; i++ )
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveNumber++;
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
