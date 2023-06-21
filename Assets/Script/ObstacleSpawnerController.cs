using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerController : MonoBehaviour
{
    public GameObject obstacle1, obstacle2;
    private float obstacleSpawnInterval = 2.5f;

    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private void SpawnObstacle()
    {
        int random = Random.Range(1, 3);
        if (random == 1)
        {
            Instantiate(obstacle1, new Vector3(transform.position.x + 0.5f, 0.5f, 0), Quaternion.identity);
        }
        else if (random == 2)
        {
            Instantiate(obstacle2, new Vector3(transform.position.x +1, 0.5f, 0), Quaternion.identity);
        }
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(obstacleSpawnInterval);
        }
    }
}
