using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject explosionPrefab;
    public GameObject goldCoinPrefab;
    public float goldCoinSpeed = 5f;
    private int raiCount; // Số lượng quái Rai còn lại
    private ParallaxController parallaxController;
    private PlayerController playerController;
    public float goldCoinZ = -6f;

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        raiCount = GameObject.FindGameObjectsWithTag("Rai").Length; // Khởi tạo số lượng quái Rai
        Debug.Log(raiCount);

        parallaxController = FindObjectOfType<ParallaxController>(); // Tìm và lưu trữ tham chiếu đến ParallaxController
        playerController = FindObjectOfType<PlayerController>(); // Tìm và lưu trữ tham chiếu đến PlayerController
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

            if (raiCount >= 1)
            {
                raiCount--; // Giảm số lượng quái Rai còn lại
                SpawnController spawnController = FindObjectOfType<SpawnController>();
                // Kiểm tra nếu spawnController không null
                if (spawnController != null)
                {

                    // Tạo đồng vàng và di chuyển nó đến người chơi
                    GameObject goldCoin = Instantiate(goldCoinPrefab, transform.position, Quaternion.identity);
                    goldCoin.transform.position = new Vector3(goldCoin.transform.position.x, goldCoin.transform.position.y, goldCoinZ);
                    Rigidbody2D goldCoinRigidbody = goldCoin.GetComponent<Rigidbody2D>();
                }
            }


            if (raiCount == 0)
            {
                SpawnController spawnController = FindObjectOfType<SpawnController>();
                if (spawnController != null)
                {
                    spawnController.SpawnBoss(); // Sinh ra quái BigRai khi bắn hết quái Rai
                    parallaxController.BossRaiAppeared(); // Gọi phương thức BossRaiAppeared() của ParallaxController
                    playerController.StopAnimation(); // Gọi phương thức StopAnimation() của PlayerController
                }
            }
        }
        else if (collision.gameObject.CompareTag("BigRai"))
        {
            gameObject.SetActive(false);
            FindObjectOfType<HeathBarController>().DecreaseHealth(1f);
            parallaxController.BossRaiAppeared(); // Gọi phương thức BossRaiAppeared() của ParallaxController
            playerController.StopAnimation(); // Gọi phương thức StopAnimation() của PlayerController
        }
    }
}

