using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBossController : MonoBehaviour
{
    public GameObject bossPrefab;
    public float yPosition = -1.93f;

    public void SpawnBoss()
    {
        Instantiate(bossPrefab, new Vector3(7.08f, yPosition, 0f), Quaternion.identity);
    }
}
