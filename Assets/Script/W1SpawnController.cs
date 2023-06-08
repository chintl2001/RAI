using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs;
    public GameObject dronePrefab;
    public List<GameObject> raiPrefabs;

    public List<Transform> positions; // Danh sách các vị trí khác nhau

    private void Start()
    {
        // Tạo một biến tạm để lưu trữ giá trị ban đầu của dronePrefab
        GameObject originalDronePrefab = dronePrefab;

        // Gán giá trị cho các biến prefab và danh sách prefab
        Instantiate(originalDronePrefab, positions[0].position, Quaternion.identity);
        Instantiate(originalDronePrefab, positions[3].position, Quaternion.identity);

        // Sinh ngẫu nhiên các prefab từ danh sách prefab
        GameObject randomObstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];
        Instantiate(randomObstaclePrefab, positions[2].position, Quaternion.identity);

        GameObject randomRaiPrefab = raiPrefabs[Random.Range(0, raiPrefabs.Count)];
        Instantiate(randomRaiPrefab, positions[1].position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        // Kiểm tra nếu game object va chạm có tag trùng khớp với targetTag
        if (collision.gameObject.CompareTag("Rai") && collision.gameObject.CompareTag("Obstacle"))
        {
            // Xóa game object hiện tại
            Destroy(gameObject);
        }
    }
}
