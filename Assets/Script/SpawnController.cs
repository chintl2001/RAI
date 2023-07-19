using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnController : MonoBehaviour, IDataPresistent
{
    public ObjectPooling objectPool;
    public GameObject enemyPrefab;
    public Transform playerTransform;
    public float minDistanceBetweenEnemies = 3f;
    public float maxDistanceBetweenEnemies = 10f;
    public int totalNumberOfEnemies = 10;
    public float yPosition = -3.321175f;
    public SpawnBossController bossSpawnController;
    public static SpawnController instance;
    private bool hasSpawnedEnemies = false;

    private bool isInitialSpawnComplete = false;

    private List<Vector3> enemyPositions = new List<Vector3>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (!isInitialSpawnComplete && !hasSpawnedEnemies)
        {
            SpawnEnemies();
            isInitialSpawnComplete = true;
        }
    }

    private void SpawnEnemies()
    {
        // Determine if there is saved data
        GameData savedData = LoadSavedGameData();

        if (savedData != null && savedData.enemyPositions != null)
        {
            // If there is saved data, spawn enemies from the data
            SpawnEnemiesFromData(savedData);
        }
        else if (!hasSpawnedEnemies) // Only spawn if not spawned before
        {
            SpawnInitialEnemies();
            hasSpawnedEnemies = true; // Mark as spawned
        }
    }

    private GameData LoadSavedGameData()
    {
        // Read saved data from PlayerPrefs or other file
        string savedDataString = PlayerPrefs.GetString("GameData");

        // Convert the saved string to GameData object
        GameData savedData = JsonUtility.FromJson<GameData>(savedDataString);

        return savedData;
    }

    private void SpawnEnemiesFromData(GameData data)
    {
        foreach (Vector3 enemyPosition in data.enemyPositions)
        {
            GameObject prefab = objectPool.GetPooledObject();
            prefab.transform.position = enemyPosition;
            prefab.SetActive(true);
        }

        hasSpawnedEnemies = true; // Mark as spawned from data
    }

    private void SpawnInitialEnemies()
    {
        // Spawn initial enemies
        float currentPosition = 0f;
        List<float> distances = GenerateRandomDistances(totalNumberOfEnemies, minDistanceBetweenEnemies, maxDistanceBetweenEnemies);

        for (int i = 0; i < totalNumberOfEnemies; i++)
        {
            Vector3 spawnPosition = new Vector3(currentPosition, yPosition, 0f);

            GameObject prefab = objectPool.GetPooledObject();
            prefab.transform.position = spawnPosition;
            prefab.SetActive(true);

            enemyPositions.Add(spawnPosition);

            // Update current position for the next enemy
            currentPosition += distances[i];
        }
    }

    public void ResetSpawnState()
    {
        hasSpawnedEnemies = false;
    }

    private List<float> GenerateRandomDistances(int numberOfDistances, float minDistance, float maxDistance)
    {
        List<float> distances = new List<float>();

        for (int i = 0; i < numberOfDistances; i++)
        {
            float distance = Random.Range(minDistance, maxDistance);
            distances.Add(distance);
        }

        return distances;
    }

    public void SpawnBoss()
    {
        if (bossSpawnController != null)
        {
            bossSpawnController.SpawnBoss();
        }
    }

    public void LoadData(GameData data)
    {
        // Check if there are enemy positions in the GameData object
        if (data != null && data.enemyPositions != null)
        {
            // Clear all previously spawned enemies
            List<GameObject> spawnedEnemies = objectPool.GetSpawnedObjects();
            foreach (GameObject enemy in spawnedEnemies)
            {
                objectPool.ReturnToPool(enemy);
            }

            // Spawn enemies from the position list in the GameData object
            foreach (Vector3 enemyPosition in data.enemyPositions)
            {
                GameObject prefab = objectPool.GetPooledObject();
                prefab.transform.position = enemyPosition;
                prefab.SetActive(true);
            }
        }
    }

    public void SaveData(ref GameData data)
    {
        // Create a new GameData object if it doesn't exist
        if (data == null)
        {
            data = new GameData();
        }

        // Clear the enemy position list in the GameData to store new data
        data.enemyPositions.Clear();

        // Iterate over all spawned enemies and store their positions in the GameData object
        List<GameObject> spawnedEnemies = objectPool.GetSpawnedObjects();
        foreach (GameObject enemy in spawnedEnemies)
        {
            data.enemyPositions.Add(enemy.transform.position);
        }
    }
}