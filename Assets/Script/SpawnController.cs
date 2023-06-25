using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnController : MonoBehaviour
{
    public ObjectPooling objectPool;
    public Transform playerTransform; // Transform của player
    public float distanceBetweenEnemies = 2f; // Khoảng cách giữa các quái
    public int numberOfEnemies = 10; // Số lượng quái cần spawn
    public float yPosition = -3.321175f;
    public SpawnBossController bossSpawnController;


    private void Start()
    {
        List<Transform> spawnPositions = GenerateRandomSpawnPositions(numberOfEnemies, distanceBetweenEnemies);

        for (int i = 0; i < numberOfEnemies; i++)
        {
            Transform spawnPosition = spawnPositions[i];

            GameObject prefab = objectPool.GetPooledObject();
            prefab.transform.position = spawnPosition.position;
            prefab.SetActive(true);
        }
    }

    private List<Transform> GenerateRandomSpawnPositions(int numberOfPositions, float distance)
    {
        List<Transform> spawnPositions = new List<Transform>();

        float currentPosition = 0f;

        for (int i = 0; i < numberOfPositions; i++)
        {
            currentPosition += Random.Range(distance - 0.5f, distance + 0.5f);

            // Tạo một GameObject tạm để lưu trữ vị trí spawn
            GameObject spawnPositionObject = new GameObject("SpawnPosition");
            spawnPositionObject.transform.position = new Vector3(currentPosition, yPosition, 0f);
            spawnPositions.Add(spawnPositionObject.transform);
        }

        return spawnPositions;
    }

    public void SpawnBoss()
    {
        if (bossSpawnController != null)
        {
            bossSpawnController.SpawnBoss();
        }
    }


}
