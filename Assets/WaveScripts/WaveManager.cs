using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public int currentWave = 1;             
    public int enemiesPerWave = 5;          
    public int maxEnemiesPerWave = 20;      
    public float enemyHealthMultiplier = 1.2f; 
    public GameObject enemyPrefab1;         
    public GameObject enemyPrefab2;         
    public Transform[] spawnPoints;         
    public Text waveNumberText;             
    public Text countdownText;              
    public Button startWaveButton;          

    private int enemiesRemaining;           
    private bool isWaveInProgress = false;  

    public GameObject menuCanvas;

    void Start()
    {
        if (enemyPrefab1 == null || enemyPrefab2 == null) Debug.LogError("Enemy prefabs er ikke sat!");
        if (waveNumberText == null) Debug.LogError("Wave nummer tekst er ikke sat!");
        if (countdownText == null) Debug.LogError("Countdown tekst er ikke sat!");
        if (spawnPoints.Length == 0) Debug.LogError("Spawn points er ikke sat!");
        if (startWaveButton == null) Debug.LogError("Start wave knap er ikke sat!");

        startWaveButton.gameObject.SetActive(false);
        startWaveButton.onClick.AddListener(OnStartWaveButtonPressed);

        StartWave(); 
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && !isWaveInProgress)
        {
            isWaveInProgress = true; 
            ShowStartWaveButton();
        }
    }

    void ShowStartWaveButton()
    {
        menuCanvas.SetActive(true);
        startWaveButton.gameObject.SetActive(true);
        Text buttonText = startWaveButton.GetComponentInChildren<Text>();
        if (buttonText != null)
        {
            buttonText.text = "Start Next Wave";
        }
        else
        {
            Debug.LogError("Start Wave Button Text is not set!");
        }
    }


    void OnStartWaveButtonPressed()
    {
        menuCanvas.SetActive(false);
        startWaveButton.gameObject.SetActive(false);
        StartCoroutine(ShowCountdownAndStartNextWave());
    }

    IEnumerator ShowCountdownAndStartNextWave()
    {
        for (int i = 5; i > 0; i--)
        {
            if (countdownText != null)
            {
                countdownText.text = "Ny wave starter om: " + i + " sekunder";
            }
            yield return new WaitForSeconds(1f);
        }

        countdownText.text = ""; 
        StartWave(); 
    }

    void StartWave()
    {
        Debug.Log("Starting Wave: " + currentWave); 
        currentWave++;
        int enemiesToSpawn = Mathf.Min(enemiesPerWave + (currentWave - 1), maxEnemiesPerWave);
        enemiesRemaining = enemiesToSpawn;

        if (waveNumberText != null)
        {
            waveNumberText.text = "Wave: " + currentWave;
        }

        StartCoroutine(SpawnEnemies(enemiesToSpawn));
    }

    IEnumerator SpawnEnemies(int count)
    {
        Debug.Log("Spawning " + count + " enemies."); 
        for (int i = 0; i < count; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f); 
        }
        isWaveInProgress = false; 
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("Ingen spawn points tilgængelige!");
            return;
        }

        int spawnIndex = Random.Range(0, spawnPoints.Length);
        GameObject enemy = null;

        try
        {
            if (enemyPrefab1 != null && enemyPrefab2 != null)
            {
                if (Random.value < 0.5f)
                {
                    enemy = Instantiate(enemyPrefab1, spawnPoints[spawnIndex].position, Quaternion.identity);
                }
                else
                {
                    enemy = Instantiate(enemyPrefab2, spawnPoints[spawnIndex].position, Quaternion.identity);
                }

                if (enemy != null)
                {
                    var enemyHealth = enemy.GetComponent<EnemyHealth>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.SetHealth(enemyHealth.GetBaseHealth() * Mathf.Pow(enemyHealthMultiplier, currentWave - 1));
                    }

                    var enemyLogic = enemy.GetComponent<enemyLogic>();
                    var enemyType2 = enemy.GetComponent<EnemyType2behaviour>();

                    if (enemyLogic != null)
                    {
                        enemyLogic.OnDeath += HandleEnemyDeath;
                    }
                    else if (enemyType2 != null)
                    {
                        enemyType2.OnDeath += HandleEnemyDeath;
                    }
                }
            }
            else
            {
                Debug.LogError("Enemy prefabs are missing or not assigned correctly.");
            }
        }
        catch (MissingReferenceException e)
        {
            Debug.LogError("Error spawning enemy: " + e.Message);
        }
    }

    void HandleEnemyDeath()
    {
        enemiesRemaining--;
        if (enemiesRemaining <= 0) // No more enemies
        {
            isWaveInProgress = false; // Wave has ended
            
            ShowStartWaveButton(); // Show button to start the next wave
        }
    }


    void CheckWinCondition()
    {
        if (currentWave >= 10) 
        {
            Debug.Log("Tillykke, du har vundet!");
        }
    }
}