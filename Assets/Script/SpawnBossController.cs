using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBossController : MonoBehaviour
{
    public GameObject bossPrefab;
    public float yPosition = -1.41f;

    public void SpawnBoss()
    {
        Instantiate(bossPrefab, new Vector3(0f, yPosition, 0f), Quaternion.identity);
    }
}
