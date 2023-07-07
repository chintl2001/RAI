using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public BulletPooling bulletPool; // Tham chiếu đến lớp BulletPooling
    public GameObject player; // Tham chiếu đến prefab player
    public float fireInterval = 3f; // Thời gian giữa các lần bắn
    private float nextFireTime;
    private float bulletSpeed = 100f;

    private void Start()
    {
        bulletPool = FindObjectOfType<BulletPooling>();
        // Các xử lý khác...
    }
    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            FireBullet();
            nextFireTime = Time.time + fireInterval;
        }
    }

    private void FireBullet()
    {
        GameObject bullet = bulletPool.GetPooledBullet(); // Lấy đối tượng đạn từ pool
        bullet.transform.position = transform.position;
        Vector3 playerDirection = (player.transform.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = playerDirection * bulletSpeed;
    }
}
