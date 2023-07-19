using UnityEngine;

public class SpawnControllerManager : MonoBehaviour
{
    public static SpawnControllerManager instance;
    public SpawnController spawnController;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}