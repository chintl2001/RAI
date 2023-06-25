using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBarController : MonoBehaviour
{
    public GameObject explosionPrefab;
    public Image background; // Hình ảnh background
    public Image foreground; // Hình ảnh foreground
    public float maxHealth = 5f; // Sức mạnh tối đa
    private float health; // Sức mạnh hiện tại
    private int enemyCount; // Số lượng quái

    private void Start()
    {
        health = maxHealth;
        enemyCount = GameObject.FindGameObjectsWithTag("Rai").Length;
        Debug.Log("Enemy Count: " + enemyCount);
        UpdateHealthUI();
    }

    public void DecreaseHealth(float amount)
    {
        health -= amount;
        UpdateHealthUI();

        if (health <= 0)
        {
            DestroyEnemy();
        }
    }

    private void UpdateHealthUI()
    {
        foreground.fillAmount = health / maxHealth;
    }

    private void DestroyEnemy()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public bool IsAllEnemiesDestroyed()
    {
        return enemyCount <= 0;
    }

    public void DecreaseEnemyCount()
    {
        enemyCount--;
    }
}
