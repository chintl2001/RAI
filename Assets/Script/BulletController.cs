using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject explosionPrefab;
    private int raiCount; // Số lượng quái Rai còn lại

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        raiCount = GameObject.FindGameObjectsWithTag("Rai").Length; // Khởi tạo số lượng quái Rai
        Debug.Log(raiCount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rai"))
        {
            FindObjectOfType<GameManager>().IncreaseRai();
            Instantiate(explosionPrefab, collision.gameObject.transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);

            raiCount--; // Giảm số lượng quái Rai còn lại

            if (raiCount == 0)
            {
                SpawnController spawnController = FindObjectOfType<SpawnController>();
                if (spawnController != null)
                {
                    spawnController.SpawnBoss(); // Sinh ra quái BigRai khi bắn hết quái Rai
                }
            }
        }
        else if (collision.gameObject.CompareTag("BigRai"))
        {
            HeathBarController healthBar = collision.gameObject.GetComponent<HeathBarController>();
            if (healthBar != null)
            {
                healthBar.DecreaseHealth(1f);
            }
        }
    }
}
