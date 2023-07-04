using UnityEngine;

public class GoldCoinController : MonoBehaviour
{
    public string playerTag = "Player"; // Tag của đối tượng người chơi
    private Transform playerTransform; // Tham chiếu đến Transform của người chơi
    public float moveSpeed = 5f; // Tốc độ di chuyển của đồng vàng
    public AudioClip coinCollectSound; // Âm thanh khi thu thập đồng vàng
    private AudioSource audioSource; // Thành phần AudioSource để phát âm thanh

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
            playerTransform.position = new Vector3(-7f, -3.321175f, 0f); // Đặt vị trí cố định cho người chơi
        }
        else
        {
            Debug.LogWarning("Player object not found!");
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            // Di chuyển đồng vàng theo hướng người chơi
            Vector3 moveDirection = (playerTransform.position - transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            // Xử lý khi đồng vàng va chạm với người chơi
            CollectCoin();
        }
    }

    private void CollectCoin()
    {
        // Phát âm thanh khi thu thập đồng vàng
        if (coinCollectSound != null)
        {
            audioSource.PlayOneShot(coinCollectSound);
        }

        Debug.Log("Coin collected!");
        Destroy(gameObject);
    }
}
