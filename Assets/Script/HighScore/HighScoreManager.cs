using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    private static HighScoreManager instance;

    public HighScoreList highScoreList;

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

    public static HighScoreManager Instance
    {
        get { return instance; }
    }
}
