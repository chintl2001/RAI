using UnityEngine;

public class TempJSONGenerator : MonoBehaviour
{
    void Start()
    {
        // Tạo một JSON tạm thời
        ScoreData scoreData = new ScoreData();
        scoreData.scores.Add(new Score("Player 1", 1000));
        scoreData.scores.Add(new Score("Player 2", 2000));
        scoreData.scores.Add(new Score("Player 3", 1500));

        // Chuyển đổi đối tượng ScoreData thành chuỗi JSON
        string json = JsonUtility.ToJson(scoreData);

        // Lưu chuỗi JSON vào PlayerPrefs
        PlayerPrefs.SetString("scores", json);
        PlayerPrefs.Save();
    }
}
