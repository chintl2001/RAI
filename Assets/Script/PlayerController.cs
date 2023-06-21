using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDataPresistent
{
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    private bool isJumping = false;

    public GameObject bulletPrefab;

    public float bulletForce = 10f;

    public GameObject bulletPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FireBullet()
    {
        // Tạo một viên đạn từ prefab
        GameObject bullet = Instantiate(bulletPrefab, bulletPosition.transform.position, Quaternion.identity);

        // Lấy tham chiếu tới Rigidbody2D của viên đạn
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();


        // Tính toán hướng di chuyển và khoảng cách dựa trên hai điểm pivot
        Vector2 moveDirection = (GameObject.FindGameObjectWithTag("Pivot").transform.position - bulletPosition.transform.position).normalized;
        // Áp dụng lực đẩy theo hướng của nòng súng
        bulletRigidbody.AddForce(moveDirection * bulletForce, ForceMode2D.Force);
    }

    private void Update()
    {
        if (isJumping)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SoundManager.PlaySound("gunshot");
                FireBullet();
            }
            return;
        }

        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput != 0)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.PlaySound("gunshot");
            FireBullet();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition= this.transform.position;
    }
}
