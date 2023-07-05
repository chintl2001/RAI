/*using UnityEngine;
using System.IO;

public class HighScoreManager : MonoBehaviour
{
    private string highScoresFilePath;
    private HighScoreData highScoreData;

    private void Awake()
    {
        // Đường dẫn đến tệp highscores.json trong thư mục persistent data
        highScoresFilePath = Path.Combine(Application.persistentDataPath, "highscores.json");
    }

    public void SaveHighScores()
    {
        string jsonData = JsonUtility.ToJson(highScoreData);
        File.WriteAllText(highScoresFilePath, jsonData);
    }

    public void x1()
    {
        if (File.Exists(highScoresFilePath))
        {
            string jsonData = File.ReadAllText(highScoresFilePath);
            highScoreData = JsonUtility.FromJson<HighScoreData>(jsonData);
        }
        else
        {
            // Tạo dữ liệu mặc định nếu không có tệp highscores.json
            highScoreData = new HighScoreData();
        }
    }

    public void AddHighScore(string playerName, int score)
    {
        HighScoreEntry entry = new HighScoreEntry();
        entry.playerName = playerName;
        entry.score = score;
        highScoreData.highScores.Add(entry);
        SaveHighScores();
    }
}
*/