using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Button startWave;

    private int waveNumber = 1;
    private int enemyAmount = 3;
    private float nextwaveTimer = 15f;

    void Start()
    {
        StartCoroutine(SpawnLackeys(enemyAmount)); // Then the wave starts (courutine)
    }
    void Update()
    {
        nextwaveTimer -= Time.deltaTime; // Countdown until next wave

        if(nextwaveTimer <= 0 && waveNumber < 10)
        {
            Debug.Log("Next wave incoming");

            enemyAmount += 2; // The amount of enemies increasing with each wave
            // Update their stats as well
            StartCoroutine(SpawnLackeys(enemyAmount)); // Spawn a new wave

            nextwaveTimer = 15f; // Reset the timer
            waveNumber++;

            Debug.Log("Wave number:" + waveNumber);
        }
        else if (waveNumber == 10)
        {
            Debug.Log("Wave 10. Boss Incoming");
        }
    }

    IEnumerator SpawnLackeys(int _enemyAmount)
    {
        for (int i = 0; i < _enemyAmount; i++)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(3);
        }

    }


    // The difficulty increasees, the hp and speed, the amount.
}
