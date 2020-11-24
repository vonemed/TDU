using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Header("Regular Enemies")]
    public GameObject sphereLackeyPrefab;
    public GameObject cubeKnightPrefab;
    public GameObject cylinderCommanderPrefab;

    [Header("Bosses")]
    public GameObject kingSphere;
    public GameObject lordCube;
    public GameObject eternalCylinder;

    private GameObject sphereLackey;
    private GameObject cubeKnight;
    private GameObject cylinderCommander;

    [Header("General")]
    public Transform spawnPoint;
    public Button startWave;

    private int waveNumber = 1;
    private int enemyAmount = 3;
    private float nextwaveTimer = 15f;
    private bool nextWave;
    public Text waveCountdowntext;

    void Start()
    {
        startWave.onClick.AddListener(StartNextWave);
    }
    void Update()
    {
        // breaks out of loop if game is over
        if (GameManager.gameEnded)
            return;

        nextwaveTimer -= Time.deltaTime; // Countdown until next wave

        // Clamping countdown value between 0 and infinity, so it can be displayed better to the player (makes it so that the countdown timer would never be less than zero)
        nextwaveTimer = Mathf.Clamp(nextwaveTimer, 0f, Mathf.Infinity);
        // Displays the time until next wave in seconds AND milliseconds (in-game UI)
        waveCountdowntext.text = string.Format("{0:00.00}", nextwaveTimer);

        if (nextwaveTimer <= 0 || nextWave == true)
        {
            if(waveNumber == 10)
            {
                Instantiate(kingSphere, spawnPoint.position, spawnPoint.rotation);

            } else if (waveNumber == 20)
            {
                Instantiate(lordCube, spawnPoint.position, spawnPoint.rotation);

            } else if (waveNumber == 30)
            {
                Instantiate(eternalCylinder, spawnPoint.position, spawnPoint.rotation);
            }

            enemyAmount += 2; // The amount of enemies increasing with each wave
            // Update their stats as well

            if (waveNumber <= 10)
            {
                StartCoroutine(SpawnLackeys(enemyAmount)); // Spawn a new wave

            } else if (waveNumber >= 11 && waveNumber <= 19)
            {
                StartCoroutine(SpawnKnights(enemyAmount));

            } else if (waveNumber >= 20)
            {
                StartCoroutine(SpawnCommanders(enemyAmount));
            }

            nextwaveTimer = 15f; // Reset the timer
            PlayerStats.Rounds++;
            waveNumber++;


            Debug.Log("Wave number:" + waveNumber);
            nextWave = false;
        }
    }

    IEnumerator SpawnLackeys(int _enemyAmount)
    {
        for (int i = 0; i < _enemyAmount; i++)
        {
            sphereLackey = (GameObject)Instantiate(sphereLackeyPrefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator SpawnKnights(int _enemyAmount)
    {
        for (int i = 0; i < _enemyAmount; i++)
        {
            cubeKnight = (GameObject)Instantiate(cubeKnightPrefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator SpawnCommanders(int _enemyAmount)
    {
        for (int i = 0; i < _enemyAmount; i++)
        {
            cylinderCommander = (GameObject)Instantiate(cylinderCommanderPrefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(1);
        }
    }

    void StartNextWave()
    {
        nextWave = true;
    }
}
