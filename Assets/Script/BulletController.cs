using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rai"))
        {
            FindObjectOfType<GameManager>().IncreaseRai();
            Instantiate(explosionPrefab, collision.gameObject.transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("BigRai"))
        {
            HeathBarController healthBar = collision.gameObject.GetComponent<HeathBarController>();
            if (healthBar != null)
            {
                healthBar.DecreaseHealth(1f);
            }

            if (healthBar != null && healthBar.IsAllEnemiesDestroyed())
            {
                SpawnController spawnController = FindObjectOfType<SpawnController>();
                if (spawnController != null)
                {
                    spawnController.SpawnBoss(); // Sinh ra quái tinh khi bắn hết số lượng quái
                }
            }
        }
    }
}
