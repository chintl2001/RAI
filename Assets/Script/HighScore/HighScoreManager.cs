using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    private void Start()
    {
        // Tạo dữ liệu cao nhất
        HighScoreData highScore = new HighScoreData();
        highScore.name = "John";
        highScore.score = 100;

        // Chuyển dữ liệu thành chuỗi JSON
        string highScoreJson = JsonUtility.ToJson(highScore);

        // Lưu trữ dữ liệu cao nhất dưới dạng chuỗi JSON
        PlayerPrefs.SetString("HighScoreData", highScoreJson);
    }

    [System.Serializable]
    private class HighScoreData
    {
        public string name;
        public int score;
    }
}
