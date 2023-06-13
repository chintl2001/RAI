using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W2SpawnController : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs;
    public GameObject dronePrefab;
    public List<GameObject> raiPrefabs;

    public List<Transform> positions; // Danh sách các vị trí khác nhau

    private void Start()
    {
        // Gán giá trị cho các biến prefab và danh sách prefab
        dronePrefab = Instantiate(dronePrefab, positions[0].position, Quaternion.identity);
        int i = Random.Range(0, 5);
        // Sinh ngẫu nhiên các prefab từ danh sách prefab
        GameObject randomObstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];
        Instantiate(randomObstaclePrefab, positions[2].position, Quaternion.identity);

        GameObject randomRaiPrefab = raiPrefabs[Random.Range(0, raiPrefabs.Count)];
        Instantiate(randomRaiPrefab, positions[1].position, Quaternion.identity);
        Instantiate(randomRaiPrefab, positions[3].position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
