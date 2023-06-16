using UnityEngine;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        // Lấy dữ liệu tên và điểm số cao nhất từ PlayerPrefs (đã lưu dưới dạng JSON)
        string highScoreData = PlayerPrefs.GetString("HighScoreData");
        HighScoreData data = JsonUtility.FromJson<HighScoreData>(highScoreData);

        // Hiển thị dữ liệu trên cùng một dòng
        highScoreText.text = "Name: " + data.name + " - Score: " + data.score.ToString();
    }

    [System.Serializable]
    private class HighScoreData
    {
        public string name;
        public int score;
    }
}
